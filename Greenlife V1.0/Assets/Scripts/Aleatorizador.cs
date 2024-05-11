using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 200;
    public int height = 50;
    public float smoothness = 0.01f; // Suavidade do terreno
    public float hillHeight = 0.2f; // Altura das colinas
    public float valleyDepth = 0.1f; // Profundidade dos vales
    public int numTrees = 100; // Número de árvores
    public float treeSpacing = 5f; // Espaçamento entre as árvores
    public int numRivers = 2; // Número de rios
    public float riverWidth = 5f; // Largura do rio
    public float riverDepth = 2f; // Profundidade do rio
    public int riverPointSpacing = 10; // Espaçamento entre os pontos do rio

    private List<Vector2Int> riverPoints = new List<Vector2Int>();

    void Start()
    {
        GenerateTerrain();
        CreateRivers();
        PlantTrees();
    }

    void GenerateTerrain()
    {
        Terrain terrain = GetComponent<Terrain>();
        TerrainData terrainData = terrain.terrainData;
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, height, width);

        float[,] heights = GenerateHeights();
        terrainData.SetHeights(0, 0, heights);
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, width];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < width; y++)
            {
                float xCoord = (float)x / width * smoothness;
                float yCoord = (float)y / width * smoothness;

                float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);

                // Adiciona colinas
                perlinValue += Mathf.PerlinNoise(xCoord * 0.3f, yCoord * 0.3f) * hillHeight;

                // Cria vales
                perlinValue -= Mathf.PerlinNoise(xCoord * 0.1f, yCoord * 0.1f) * valleyDepth;

                heights[x, y] = perlinValue;
            }
        }

        return heights;
    }

    void CreateRivers()
    {
        for (int i = 0; i < numRivers; i++)
        {
            Vector2Int start = new Vector2Int(Random.Range(0, width), Random.Range(0, width));
            Vector2Int end = new Vector2Int(Random.Range(0, width), Random.Range(0, width));
            CreateRiver(start, end);
        }
    }

    void CreateRiver(Vector2Int start, Vector2Int end)
    {
        Vector2Int currentPoint = start;
        riverPoints.Add(currentPoint);

        while (currentPoint != end)
        {
            int nextX = currentPoint.x + Mathf.RoundToInt(Mathf.Sign(end.x - currentPoint.x));
            int nextY = currentPoint.y + Mathf.RoundToInt(Mathf.Sign(end.y - currentPoint.y));
            currentPoint = new Vector2Int(nextX, nextY);
            riverPoints.Add(currentPoint);
            Vector2Int randomOffset = new Vector2Int(Mathf.RoundToInt(Random.Range(-1f, 1f)), Mathf.RoundToInt(Random.Range(-1f, 1f)));
            currentPoint += randomOffset * riverPointSpacing; // Adiciona um pouco de aleatoriedade ao caminho do rio
        }
    }

    void PlantTrees()
    {
        Terrain terrain = GetComponent<Terrain>();
        TerrainData terrainData = terrain.terrainData;

        for (int i = 0; i < numTrees; i++)
        {
            float treeX = Random.Range(0f, terrainData.size.x);
            float treeZ = Random.Range(0f, terrainData.size.z);

            Vector3 treePosition = new Vector3(treeX, 0f, treeZ);
            treePosition.y = terrain.SampleHeight(treePosition) + 1f; // Ajuste para a altura do terreno

            // Verifica se a árvore está muito próxima de um rio
            bool tooCloseToRiver = false;
            foreach (Vector2Int riverPoint in riverPoints)
            {
                float distanceToRiver = Vector2.Distance(new Vector2(treePosition.x, treePosition.z), riverPoint);
                if (distanceToRiver < riverWidth / 2)
                {
                    tooCloseToRiver = true;
                    break;
                }
            }

            // Se não estiver muito próxima de um rio, planta a árvore
            if (!tooCloseToRiver)
            {
                GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cube);
                tree.transform.position = treePosition;
                tree.transform.localScale = new Vector3(1f, 3f, 1f); // Ajuste para o tamanho da árvore
                tree.GetComponent<Renderer>().material.color = Color.green; // Ajuste para a cor da árvore
            }
        }
    }
}