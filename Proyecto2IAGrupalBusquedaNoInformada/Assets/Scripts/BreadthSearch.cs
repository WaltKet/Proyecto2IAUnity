using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadthSearch : MonoBehaviour
{
	public Graph graph;
	public int endValue;
	public int beginingValue;
	public BSNode end;
	public BSNode begining;
	public List<BSNode> UgandaKnukles = new List<BSNode>();
	public BSNode searchBFS(float data, BSNode start)
	{
		List<BSNode> visited = new List<BSNode>();
		Queue<BSNode> queue = new Queue<BSNode>();

		//data = endValue;
		//start = begining;

		

		visited.Add(start);
		queue.Enqueue(start);

		while (queue.Count > 0)
		{
			start = queue.Peek();
			if (start.getData().Equals(data)) return start;
			queue.Dequeue();

			for (int i = 0; i < start.adyacentes.Count; i++)
			{
				BSNode tmp = start.adyacentes[i];

				if (!visited.Contains(tmp))
				{
					visited.Add(tmp);
					queue.Enqueue(tmp);
					StartCoroutine(ColorCoroutine(visited));
					UgandaKnukles.Add(tmp);
					Debug.Log("lol " + tmp.data);
				}
			}
		}

		return null;
	}
    private void Start()
    {
		//searchBFS(endValue, begining);
	
	}

    private void OnMouseDown()
    {
		Debug.Log(searchBFS(endValue, begining).data);
	}

	IEnumerator ColorCoroutine(List<BSNode> bSNodes)
	{
		SpriteRenderer spriteRenderer;
		yield return new WaitForSeconds(2);
		for (int i = 0; i < bSNodes.Count; i++)
		{
			yield return new WaitForSeconds(2);
			spriteRenderer = bSNodes[i].transform.GetComponent<SpriteRenderer>();
			spriteRenderer.color = new Color(255, 0, 0);
		}
	}
}
