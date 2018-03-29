using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour 
{
	[System.Serializable]
	public class TheCursor
	{
		public string tag;
		public Texture2D cursorTexture;
	}

	public List<TheCursor> cursorList = new List<TheCursor> ();

	void Start ()
	{
		if (cursorList.Count > 0) 
			SetCursorTexture (cursorList[0].cursorTexture);
	}

	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 1000f)) 
		{
			SetCursor (hit.collider.tag);
		}
		if (cursorList.Count > 0)
			SetCursorTexture (cursorList[0].cursorTexture);			
	}

	public void SetCursor (string tag) 
	{
		for (int i = 0; i < cursorList.Count; i++) 
		{
			if (cursorList [i].tag == tag) 
			{
				SetCursorTexture (cursorList[i].cursorTexture);
			}
		}
	}

	void SetCursorTexture (Texture2D tex)
	{
		Cursor.SetCursor (tex, Vector2.zero, CursorMode.Auto);
	}
}
