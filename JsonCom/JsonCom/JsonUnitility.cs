using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JsonCom
{
    public static class JsonUnitility
    {
        public static string CreateJson<T>(T _object) => JsonUtility.ToJson(_object);
        public static T CreateObject<T>(string _Json) => JsonUtility.FromJson<T>(_Json);

        public static bool CheckDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            return Directory.Exists(directoryPath);
        }

        public static bool CheckFile<T>(string _filePath)
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, CreateJson(default(T)));

            return File.Exists(_filePath);
        }

        public static void WriteOnJson<T>(string _filePath, T _dataToWrite)
        {
            CheckFile<T>(_filePath);

            File.WriteAllText(_filePath, CreateJson(_dataToWrite));
        }

        public static void WriteOnJson<T>(string _filePath, string directoryPath, T _dataToWrite)
        {
            CheckDirectory(directoryPath);

            WriteOnJson(_filePath, _dataToWrite);
        }

        public static void ReadJson<T>(ref T _object, string _filePath)
        {
            CheckFile<T>(_filePath);

            _object = CreateObject<T>(File.ReadAllText(_filePath));
        }

        public static void ReadJson<T>(ref T _object, string _filePath, string directoryPath)
        {
            CheckDirectory(directoryPath);

            ReadJson(ref _object, _filePath);
        }


    }
}
