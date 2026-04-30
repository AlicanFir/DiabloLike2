using System.Runtime.Serialization.Formatters.Binary;
using Player;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public void SaveData(PlayerData dataToSave) // para crear archivos de guardado
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //formatter.Serialize(dataToSave,);
    }

    public void GetData( PlayerData dataToGet)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //object dataLoaded = (PlayerData)formatter.Deserialize();
        
    }
}
