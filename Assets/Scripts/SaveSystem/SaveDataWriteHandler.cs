using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveDataWriteHandler
{
    private static string PATH = Application.persistentDataPath + "/sd.sf";

    public static void WriteSaveData(SaveData saveData)
    {
        var binaryFormatter = new BinaryFormatter();

        using (var fileStream = new FileStream(PATH, FileMode.Create))
        {
            binaryFormatter.Serialize(fileStream, saveData);
        }
    }

    public static SaveData ReadSaveData()
    {
        if (File.Exists(PATH))
        {
            var binaryFormatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(PATH, FileMode.Open))
            {
                return binaryFormatter.Deserialize(fileStream) as SaveData;
            }
        }

        else return null;
    }
}
