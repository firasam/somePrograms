using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour{
    int _ukuranX;
    int _ukuranY;
    public Vector2 _gridSize;
    public string _namaFile;
    public GameObject[] _objects;
    MapGrid _theMap;
	// Use this for initialization
	void Start() {
        char[,] coba = LoadMapFromFile();
        //Debug.Log(coba);
        _theMap = new MapGrid(coba);

        _ukuranX = _theMap.maxX;
        _ukuranY = _theMap.maxY;
        Debug.Log("x length: " + _ukuranX);
        Debug.Log("y length: " + _ukuranY);

        for (int i = 0; i < _ukuranY; i++) {
            for (int j = 0; j < _ukuranX; j++) {
                Debug.Log("i: " + i + "j: " + j);
                GameObject theObject = ObjectMapping(_theMap.GetGrid(i,j));
                
                float posX = (_gridSize.x * j ) + this.transform.position.x;
                float posY = (_gridSize.y * -i) + this.transform.position.y;
                Instantiate(theObject, new Vector2(posX, posY), Quaternion.identity);
            }
        }
    }

    char[,] LoadMapFromFile() {
        string[] row = System.IO.File.ReadAllLines(_namaFile);
        int temp = row[0].Length;
        char[,] returned = new char[row.Length,temp];

        for (int i = 0; i < row.Length; i++) {
            char[] charArray = row[i].ToCharArray();
            for (int j = 0; j < charArray.Length; j++) {
                returned[i, j] = charArray[j];
            }
        }
        return returned;
    }

    GameObject ObjectMapping(char theChar) {
        GameObject returned;
        switch (theChar) {
            case 'a':
                returned = _objects[1];
                break;
            default:
                returned = _objects[0];
                break;
        }
        return returned;
    }
	// Update is called once per frame
	
}
