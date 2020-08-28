using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DepthSearch : MonoBehaviour
{
	public BSNode end;
	public BSNode begining;
	public BSNode last;
	public Graph graph;
	public int endvalue;
	public List<BSNode> visited;
	public BSNode lookForDPS(float data, BSNode node)
	{


		if (node.Equals(null)) return null;
		visited.Add(node);
		if (node.getData().Equals(data))
		{
			last = node;
			return node;
		}

		//Aqui se puede añadir a un stack

		for (int i = 0; i < node.adyacentes.Count; i++)
		{
			if (!node.adyacentes[i].Equals(null))
				lookForDPS(data, node.adyacentes[i]);
			if (last.getData().Equals(data))
				return last;
		}

		//Aqui se borraría del stack
		return null;
	}

	IEnumerator ChangeColor()
    {
		SpriteRenderer spriteRenderer;
		yield return new WaitForSeconds(2);
		for (int i = 0; i < visited.Count; i++)
		{
			yield return new WaitForSeconds(2);
			spriteRenderer = visited[i].transform.GetComponent<SpriteRenderer>();
			spriteRenderer.color = new Color(255, 0, 0);
		}
	}
	private void OnMouseDown()
	{
		lookForDPS(endvalue, begining);
		StartCoroutine(ChangeColor());
	}

	public void ClearBeautifulDrawing()
    {
		SceneManager.LoadScene("SampleScene");
	}
}
