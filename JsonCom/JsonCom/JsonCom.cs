using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JsonCom
{
    public static class JsonCom
    {
        public static string CreateJson<T>(T _object) => JsonUtility.ToJson(_object);
        public static T CreateObject<T>(string _object) => JsonUtility.FromJson<T>(_object);

        public static void CheckDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }

        public static void CheckFile<T>(string _filePath)
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, CreateJson(default(T)));
        }

        public static void RefreshJson<T>(string _filePath, string directoryPath, T _dataToRefresh)
        {
            CheckDirectory(directoryPath);

            File.WriteAllText(_filePath, CreateJson(_dataToRefresh));
        }

        public static void ReadJson<T>(ref T _object)
        {



        }

    }
}
