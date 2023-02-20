using UnityEngine;

public class PlayerTriggerListener : MonoBehaviour
{
    public Transform LastCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        LastCheckpoint = GameplayController.Instance.VehicleSpawnPoint;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            //Constants.Logs("Save CheckPoint");
            LastCheckpoint = other.gameObject.transform;
            HUDListner.Instance.set_Statuscheckpoint(true);
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.Savepointclip);

        }
        else if (other.gameObject.CompareTag("FinishPoint"))
        {
            GameplayController.Instance.LevelFinished();
        }
        else if (other.gameObject.CompareTag("Barrier"))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("open");
        }
        
        else if (other.gameObject.CompareTag("Stones"))
        {
            print("Stones");
            if (other.gameObject.GetComponent<TriggersProps>())
                other.gameObject.GetComponent<TriggersProps>().Releasestones();
        }
        else if (other.gameObject.CompareTag("Treebreaking"))
        {
            print("Treebreaking");
            if (other.gameObject.GetComponent<Animator>())
                other.gameObject.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("close");
        }
    }

    public void Resetposition()
    {
        Constants.Logs("ResetPosition");
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GameplayController.Instance.SelectedVehiclePrefab.transform.position = LastCheckpoint.transform.position;
        GameplayController.Instance.SelectedVehiclePrefab.transform.rotation = LastCheckpoint.transform.rotation;
    }
}
