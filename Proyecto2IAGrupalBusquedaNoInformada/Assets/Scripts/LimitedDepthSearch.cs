using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedDepthSearch : MonoBehaviour
{
	public BSNode end;
	public BSNode begining;
	public BSNode last;
	public Graph graph;
	public int endvalue;
	public List<BSNode> visited;
	public int profuncidad;
	public int profundidadMaxima;

	BSNode lookForDPSLimit(float data, BSNode node, int deep, int maxDeep)
	{

		//node = begining;
		//data = last.getData();
		//deep = profuncidad;
		//maxDeep = profundidadMaxima;
		last = graph.search(6);
		int _deep = deep;
		if (_deep <= maxDeep)
		{


			_deep++;
			if (!node) return null;
			visited.Add(node);

			if (node.getData() == data)
			{
				last = node;
				return node;

			}

			//Aqui se puede añadir a un stack
			for (int i = 0; i < node.adyacentes.Count; i++)
			{
				if (node.adyacentes[i])
                {
				lookForDPSLimit(data, node.adyacentes[i], _deep, maxDeep);

                }
				if (last.getData() == data)
				{

					_deep--;
					return last;
				}
			}
			//Aqui se borraría del stack

			return null;
		}

		return null;
	}


    private void OnMouseDown()
    {
		lookForDPSLimit(endvalue, begining, 0, 2);
		StartCoroutine(ChangeColor());

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
}
