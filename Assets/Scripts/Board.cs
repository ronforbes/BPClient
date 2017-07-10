using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	public Block[,] Blocks;
	public Block BlockPrefab;
	public const int Columns = 6, Rows = 11; // Playable area is 6x10, but the top row is for new blocks

	// Use this for initialization
	void Awake() {
		// initialize the Blocks. Create an extra row for new blocks that fall in from the top
		Blocks = new Block[Columns, Rows];

		for(int x = 0; x < Columns; x++) {
			for(int y = 0; y < Rows; y++) {
				Blocks[x, y] = Instantiate(BlockPrefab, Vector3.zero, Quaternion.identity) as Block;
				Blocks[x, y].transform.parent = transform;
				Blocks[x, y].name = "Block[" + x.ToString() + ", " + y.ToString() + "]";
				Blocks[x, y].X = x;
				Blocks[x, y].Y = y;
			}
		}
	}

	void Start () {
		// Populate the board's block types, ensuring that no adjacent blocks are the same type
		for(int x = 0; x < Columns; x++) {
			for(int y = 0; y < Rows; y++) {
				int type;

				do {
					type = Random.Range(0, Block.TypeCount);
				} while((x != 0 && Blocks[x - 1, y].Type == type) || (y != 0 && Blocks[x, y - 1].Type == type));

				Blocks[x, y].Type = type;
				Blocks[x, y].State = Block.BlockState.Idle;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
