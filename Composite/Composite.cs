
using System;
using System.Collections.Generic;

namespace BT
{
	public abstract class Composite : BTNode
	{
		protected int runningIndex;
		protected List<BTNode> children;

		protected Composite(params BTNode[] children)
		{
			runningIndex = 0;
			this.children = new List<BTNode>(children);
		}

		protected override void Enter()
		{
			runningIndex = 0;
		}

		protected override void Exit()
		{
			ClearChildren ();
		}


		public BTNode FindChild(string name)
		{
			int index;
			if (ContainChild (name, out index)) 
			{
				return children [index];
			}
			return null;
		}

		public void AddChild(BTNode child)
		{
			NameDisambiguation (child.Name);
			children.Add (child);
		}

		private void NameDisambiguation(string name)
		{
			List<String> nameList = new List<string> ();
			for (int i = 0; i < children.Count; i++) 
			{
				nameList.Add (children [i].Name);
			}
			while (nameList.Contains (name)) 
			{
				name += "*";
			}
		}
		public bool ContainChild(string name, out int index)
		{
			for (int i = 0; i < children.Count; i++) 
			{
				if (children [i].Name.Equals (name)) 
				{
					index = i;
					return true;
				}
			}
			index = -1;
			return false;
		}


		//insert the BTNode after the node of name
		public void InsertChild(string name, BTNode node)
		{
			int index;
			if(ContainChild(name,out index))
			{
				NameDisambiguation (node.Name);
				children.Insert (index + 1, node);
			}
		}

		public void ReplaceChild(string name, BTNode node)
		{
			int index;
			if(ContainChild(name,out index))
			{
				NameDisambiguation (node.Name);
				children [index] = node;
			}
		}

		public void RemoveChild(string name)
		{
			int index;
			if (ContainChild (name, out index)) 
			{
				children.RemoveAt (index);
			}
		}



		public void ClearChildren()
		{
			for (int i = 0; i < children.Count; i++) {
				children [i].Clear ();
			}
		}
	}


}