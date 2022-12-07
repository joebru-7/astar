using System;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
	public Astar Instance;

	// Start is called before the first frame update
	void Start()
	{
		Instance = this;
	}
	public List<Node> GetPath(Vector2 start, Vector2 end)
	{
		List<Node> found = new();
		List<Node> explored = new();

		found.Add(getNodeAt(start));

		while (true)
		{
			if (found.Count == 0)
			{
				throw new Exception("no path possible");
			}

			found.Sort();
			var current = found[0];
			explored.Add(current);
			found.RemoveAt(0);

			if (current.location == end)
			{
				return current.MakePath();
			}

			found.AddRange(current.getNeibours());


		}

	}

	Node getNodeAt(Vector2 pos)
	{
		throw new NotImplementedException();
	}

	public class Node
	{
		public float estimate;
		public float distance;
		public Node Parent;
		public Vector2 location;

		public IEnumerable<Node> getNeibours()
		{
			throw new NotImplementedException();
		}

		public List<Node> MakePath()
		{
			List<Node> path = Parent.MakePath(new List<Node> { this });
			path.Reverse();
			return path;
		}
		List<Node> MakePath(List<Node> prev)
		{
			prev.Add(this);
			return Parent.MakePath(prev);
		}

	}
}
