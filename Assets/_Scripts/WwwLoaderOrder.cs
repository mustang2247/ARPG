using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 顺序加载管理器
/// </summary>
public class WwwLoaderOrder {
	
	/// <summary>
	/// 队列名称
	/// </summary>
	public string orderName;

	/// <summary>
	/// 路径列表
	/// </summary>
	public List<WwwLoaderPath> pathList;

	/// <summary>
	/// 队列事件
	/// </summary>
	public WwwLoaderOrderEvent wwwLoaderOrderEvent;

	public WwwLoaderOrder(string orderName, List<WwwLoaderPath> pathList,
							WwwLoaderManager.DelegateLoaderProgress loaderProgress,
							WwwLoaderManager.DelegateLoaderComplete loaderComplete) {

		this.orderName = orderName;
		this.pathList = pathList;

		this.AttackEvent(loaderProgress, loaderComplete);
	}

	/// <summary>
	/// 附加事件
	/// </summary>
	/// <param name="loaderProgress">Loader progress.</param>
	/// <param name="loaderComplete">Loader complete.</param>
	public void AttackEvent(WwwLoaderManager.DelegateLoaderProgress loaderProgress,
							WwwLoaderManager.DelegateLoaderComplete loaderComplete) {

		if (this.wwwLoaderOrderEvent == null) {
			this.wwwLoaderOrderEvent = new WwwLoaderOrderEvent();
		}

		if (loaderProgress != null) this.wwwLoaderOrderEvent.OnLoaderProgress += loaderProgress;

		if (loaderComplete != null) this.wwwLoaderOrderEvent.OnLoaderComplete += loaderComplete;
	}

	public void RemoveEvent(WwwLoaderManager.DelegateLoaderProgress loaderProgress,
							WwwLoaderManager.DelegateLoaderComplete loaderComplete) {

		if (this.wwwLoaderOrderEvent == null) return;
	
		if (loaderProgress != null) this.wwwLoaderOrderEvent.OnLoaderProgress -=loaderProgress; 

		if (loaderComplete != null) this.wwwLoaderOrderEvent.OnLoaderComplete -= loaderComplete;


	}
}
