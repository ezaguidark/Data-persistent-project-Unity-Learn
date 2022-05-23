using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

// Fuente:  https://github.com/MichelleFuchs/StoringDataJsonUnity/blob/master/SaveJSON%20-%20FinalProject/Assets/Scripts/FileHandler.cs
// https://www.youtube.com/watch?v=KZft1p8t2lQ


// Esta clase se encarga de crear el archivo y guardarlo en el equipo.
// tambien tiene metodos para comprobar si existe el archivo y leerlo.
// sirve para guardar iterables como listas, o objetos unicos.

public static class FileHandler {

    public static void SaveToJSON<T> (List<T> toSave, string filename) {
        Debug.Log (GetPath (filename));
        string content = JsonHelper.ToJson<T> (toSave.ToArray ());
        WriteFile (GetPath (filename), content);
    }

    public static void SaveToJSON<T> (T toSave, string filename) {
        string content = JsonUtility.ToJson (toSave);
        WriteFile (GetPath (filename), content);
    }

    public static List<T> ReadListFromJSON<T> (string filename) {
        string content = ReadFile (GetPath (filename));

        if (string.IsNullOrEmpty (content) || content == "{}") {
            return new List<T> ();
        }

        List<T> res = JsonHelper.FromJson<T> (content).ToList ();

        return res;

    }

    public static T ReadFromJSON<T> (string filename) {
        string content = ReadFile (GetPath (filename));

        if (string.IsNullOrEmpty (content) || content == "{}") {
            return default (T);
        }

        T res = JsonUtility.FromJson<T> (content);

        return res;

    }

    private static string GetPath (string filename) {
        return Application.persistentDataPath + "/" + filename;
    }

    private static void WriteFile (string path, string content) {
        FileStream fileStream = new FileStream (path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter (fileStream)) {
            writer.Write (content);
        }
    }

    private static string ReadFile (string path) {
        if (File.Exists (path)) {
            using (StreamReader reader = new StreamReader (path)) {
                string content = reader.ReadToEnd ();
                return content;
            }
        }
        return "";
    }
}


// Esta clase hace toda la magia de organizar el archivo Json
// Organiza los datos en Json que contiene otro Json con un valor.
// Ese valor contiene una lista con todos los objetos de los usuarios.
// Organizados en UserName y HighScore en este caso.


public static class JsonHelper {
    public static T[] FromJson<T> (string json) {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (json);
        return wrapper.Items;
    }

    public static string ToJson<T> (T[] array) {
        Wrapper<T> wrapper = new Wrapper<T> ();
        wrapper.Items = array;
        return JsonUtility.ToJson (wrapper);
    }

    public static string ToJson<T> (T[] array, bool prettyPrint) {
        Wrapper<T> wrapper = new Wrapper<T> ();
        wrapper.Items = array;
        return JsonUtility.ToJson (wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T> {
        public T[] Items;
    }
}
