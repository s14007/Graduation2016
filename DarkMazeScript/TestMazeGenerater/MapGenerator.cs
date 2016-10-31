using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{

    public GameObject defaultWallPrefab;
    private int w = 39;
    private int h = 39;

    public GameObject wallPrefab;

    public GameObject road;


    // Use this for initialization
    void Start()
    {
        //Floorのtransformを変更する
        float floor_scale_x = (float)w / 10;
        float floor_scale_z = (float)h / 10;
        
        Transform floor = GameObject.Find("Floor").GetComponent<Transform>();
        floor.position = new Vector3(w/ 2, -0.5f, h/ 2);
        floor.localScale = new Vector3(floor_scale_x, 1.0f, floor_scale_z);

        GameObject miniMapCamera = GameObject.Find("MiniMapCamera");
        miniMapCamera.transform.position = new Vector3(floor.position.x, 30.0f, floor.position.z);
        miniMapCamera.GetComponent<Camera>().orthographicSize = ((w+ h) / 2) /2;

        block = new int[h,w];

        CreateMapSpace();

        CreateMap();
    }

    void CreateMapSpace()
    {
        for (int z = 0; z < h; z++)
        {
            for (int x = 0; x < w; x++)
            {
                if (z == 0 || z == h - 1 || x == 0 || x == w - 1)
                {
                    Instantiate(defaultWallPrefab, new Vector3(x, 0, z), Quaternion.identity);
                    block[z, x] = 1;
                }
                else if (z % 2 == 0 && x % 2 == 0)
                {
                    Instantiate(defaultWallPrefab, new Vector3(x , 0, z), Quaternion.identity);
                    block[z,x] = 1; // [偶数][偶数]
                }
                else
                {
                    block[z,x] = 0; // その他
                }
            }
        }
    }

    private int[,] block;
    private  void CreateMap()
    {
        int num = 2;
        for (int z = num; z < h - num; z += num)
        {
            for (int x = num; x < w - num; x += num)
            {
                int rand;
                if (z == num)
                {
                    if (block[z,x -(num -1)] == 1)
                    {
                        rand = Random.Range(0, 3);
                    }
                    else
                    {
                        rand = Random.Range(0, 4);
                    }
                }
                else
                {
                    if (block[z,x -(num -1)] == 1)
                    {
                        rand = Random.Range(1, 3);
                    }
                    else
                    {
                        rand = Random.Range(1, 4);
                    }
                }

                GameObject gameObject;
                Debug.Log(rand);
                float blocksize = num;
                float margin = 0.0f;

                if (blocksize == 2.0f) margin = 0.5f;
                else if (blocksize == 4.0f) margin = 1.5f;
                
                    switch (rand)
                    {
                        case 0:
                            gameObject = Instantiate(wallPrefab, new Vector3(x, 0, z - 1), Quaternion.identity) as GameObject;
                            gameObject.transform.localScale = new Vector3(1.0f, 4.0f, blocksize);
                            gameObject.transform.position = new Vector3(x, 0, z - margin);
                            block[z - 1, x] = 1;
                            break;
                        case 1:
                            gameObject = Instantiate(wallPrefab, new Vector3(x + 1, 0, z), Quaternion.identity) as GameObject;
                            gameObject.transform.localScale = new Vector3(blocksize, 4.0f, 1.0f);
                            gameObject.transform.position = new Vector3(x + margin, 0, z);
                            block[z, x + 1] = 1;
                            break;
                        case 2:
                            gameObject = Instantiate(wallPrefab, new Vector3(x, 0, z + 1), Quaternion.identity) as GameObject;
                            gameObject.transform.localScale = new Vector3(1.0f, 4.0f, blocksize);
                            gameObject.transform.position = new Vector3(x, 0, z + margin);
                            block[z + 1, x] = 1;
                            break;
                        default:
                            gameObject = Instantiate(wallPrefab, new Vector3(x - 1, 0, z), Quaternion.identity) as GameObject;
                            gameObject.transform.localScale = new Vector3(blocksize, 4.0f, 1.0f);
                            gameObject.transform.position = new Vector3(x - margin, 0, z);
                            block[z, x - 1] = 1;
                            break;
                    }
                
                
            }
        }
            }

    void Update()
    {
        
    }
}

