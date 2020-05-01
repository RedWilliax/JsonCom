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

        public static bool CheckDirectory(string _directoryPath)
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            return Directory.Exists(_directoryPath);
        }

        public static bool CheckFile<T>(string _filePath)
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, CreateJson(default(T)));

            return File.Exists(_filePath);
        }

        public static bool CheckFile(string _filePath)
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "");
                Debug.Log("We created a new file empty, It's expected ?");
            }

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

        public static void ReadJson<T>(ref T _object, string _filePath, string _directoryPath)
        {
            CheckDirectory(_directoryPath);

            ReadJson(ref _object, _filePath);
        }

        public static string GetJson(string _filePath)
        {
            CheckFile(_filePath);

            return File.ReadAllText(_filePath);
        }

        public static string GetJson(string _filePath, string _directoryPath)
        {
            CheckDirectory(_directoryPath);

            return GetJson(_filePath);
        }

    }
}
