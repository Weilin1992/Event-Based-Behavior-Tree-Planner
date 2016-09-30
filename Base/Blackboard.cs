
using System.Collections.Generic;
namespace BT{
public class Blackboard {
	private List<object> data = new List<object>();
	private List<string> name = new List<string>();

	public T GetData<T>(string dataName){
		int dataIndex = IndexOfData(dataName);
		return (T)this.data[dataIndex];
	}

	public T GetData<T>(int dataIndex){
		return (T)this.data[dataIndex];
	}
	public void SetData<T> (int dataIndex, T data){
		this.data[dataIndex] = (object) data;
	}

	public void SetData<T>(string dataName, T data)
	{
		int dataIndex = IndexOfData(dataName);
		if (dataIndex == -1){
			addData<T>(dataName,data);
		}
		else this.data[dataIndex] = (object) data;
	}

	public void addData<T> (string dataName, T data){
		this.data.Add((object)data);
		this.name.Add(dataName);
	}


	public int IndexOfData(string dataName){
		for(int i = 0; i < name.Count; i++)
		{
			if (name[i].Equals(dataName)){
				return i;
			}
		}
		return -1;
	} 
}
}