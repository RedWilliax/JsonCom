using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JsonCom
{
    public static class JsonUnitility
    {
        /// <summary>
        /// Is used to create a JSON from any object T type
        /// </summary>
        /// <param name="_object">Object with which you want to create a JSON ! Care all object cannot be used to create a JSON</param>
        /// <returns></returns>
        public static string CreateJson<T>(T _object) => JsonUtility.ToJson(_object);

        /// <summary>
        /// Is used to create an object from any JSON
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="_Json">JSON with which you want to create an object</param>
        /// <returns></returns>
        public static T CreateObject<T>(string _Json) => JsonUtility.FromJson<T>(_Json);

        /// <summary>
        /// Is used to check if a directory exists or not
        /// </summary>
        /// <param name="_directoryPath">Path of directory to check</param>
        /// <returns></returns>
        public static bool CheckDirectory(string _directoryPath)
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            return Directory.Exists(_directoryPath);
        }

        /// <summary>
        /// Is used to check if a file exists or not
        /// </summary>
        /// <typeparam name="T">Type of an object which created if file doesn't exists</typeparam>
        /// <param name="_filePath">Path of file to check</param>
        /// <returns></returns>
        public static bool CheckFile<T>(string _filePath)
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, CreateJson(default(T)));
                Debug.Log("We created a new file empty, It's expected ?");
            }

            return File.Exists(_filePath);
        }

        /// <summary>
        /// Is used to check if a file exists or not
        /// </summary>
        /// <param name="_filePath">Path of file to check</param>
        /// <returns></returns>
        public static bool CheckFile(string _filePath)
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "");
                Debug.Log("We created a new file empty, It's expected ?");
            }

            return File.Exists(_filePath);
        }

        /// <summary>
        /// Is used to create a new file at a specified file path. If the target file already exists, It's overwritten
        /// </summary>
        /// <param name="_filePath">File's path</param>
        /// <param name="_dataToWrite">Object than you want create or overwritten</param>
        public static void WriteOnJson<T>(string _filePath, T _dataToWrite)
        {
            CheckFile<T>(_filePath);

            File.WriteAllText(_filePath, CreateJson(_dataToWrite));
        }

        /// <summary>
        /// Is used to create a new file at a specified file and directory path. If the target file already exists, It's overwritten
        /// </summary>
        /// <param name="_filePath">File's path</param>
        /// <param name="directoryPath">Directory's path</param>
        /// <param name="_dataToWrite">Object than you want create or overwritten</param>
        public static void WriteOnJson<T>(string _filePath, string directoryPath, T _dataToWrite)
        {
            CheckDirectory(directoryPath);

            WriteOnJson(_filePath, _dataToWrite);
        }

        /// <summary>
        /// Is used to get an object at a specified file path. If the target file doesn't exists, It's a default.
        /// </summary>
        /// <param name="_object">Object which get the data</param>
        /// <param name="_filePath">File's path</param>
        public static void ReadJson<T>(ref T _object, string _filePath)
        {
            CheckFile<T>(_filePath);

            _object = CreateObject<T>(File.ReadAllText(_filePath));
        }
        /// <summary>
        /// Is used to get an object at a specified file and directory path. If the target file doesn't exists, It's a default.
        /// </summary>
        /// <param name="_object">Object which get the data</param>
        /// <param name="_filePath">File's path</param>
        /// <param name="_directoryPath">Directory's path</param>
        public static void ReadJson<T>(ref T _object, string _filePath, string _directoryPath)
        {
            CheckDirectory(_directoryPath);

            ReadJson(ref _object, _filePath);
        }

        /// <summary>
        /// Is used to get a JSON at a specified file path.
        /// </summary>
        /// <param name="_filePath">File's path</param>
        /// <returns></returns>
        public static string GetJson(string _filePath)
        {
            CheckFile(_filePath);

            return File.ReadAllText(_filePath);
        }

        /// <summary>
        /// Is used to get a JSON at a specified file path and directory.
        /// </summary>
        /// <param name="_filePath">File's path</param>
        /// <param name="_directoryPath">Directory's path</param>
        /// <returns></returns>
        public static string GetJson(string _filePath, string _directoryPath)
        {
            CheckDirectory(_directoryPath);

            return GetJson(_filePath);
        }

    }
}
