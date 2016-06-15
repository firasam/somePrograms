using System.Collections;

public class MapGrid {
    char[,] theMap;
    public int maxX;
    public int maxY;

    public MapGrid(char[,] theMap) {
        this.theMap = theMap;
        maxX = theMap.GetLength(1);
        maxY = theMap.GetLength(0);
    }
	
    public char GetGrid(int x, int y) {
        
        return theMap[x,y];
    }
}
