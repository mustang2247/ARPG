﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 单个对象加载器，可单独使用加载资源
/// 可以使用这个类一个一个的加载资源
/// </summary>
public class WwwLoaderObject {
	/// <summary>
	/// 空对象
	/// </summary>
	private GameObject gameObject;

	/// <summary>
	/// 加载脚本
	/// </summary>
	private WwwLoaderItem wwwLoaderItem;

	/// <summary>
	/// 加载进度
	/// </summary>
	private WwwLoaderItem.DelegateLoaderProgress loaderProgress;

	/// <summary>
	/// 加载完成
	/// </summary>
	private WwwLoaderItem.DelegateLoaderComplete loaderComplete;

	/// <summary>
	/// 加载错误
	/// </summary>
	private WwwLoaderItem.DelegateLoaderError loaderError;

	public void Loader(string path, 
						WwwLoaderTypeEnum loaderTypeEnum, 
						int version, 
						WwwLoaderItem.DelegateLoaderProgress loaderProgress,
						WwwLoaderItem.DelegateLoaderComplete loaderComplete,
						WwwLoaderItem.DelegateLoaderError loaderError) {
	
		this.loaderProgress = loaderProgress;
		this.loaderComplete = loaderComplete;
		this.loaderError = loaderError;

		if (this.gameObject == null) {
			this.gameObject = new GameObject();
			this.gameObject.name = "ResourceLoadeManager";
		}
		this.wwwLoaderItem = this.gameObject.AddComponent<WwwLoaderItem>();

		if (this.wwwLoaderItem == null) return;

		this.wwwLoaderItem.onProgress += this.loaderProgress;
		this.wwwLoaderItem.onError += this.loaderError;
		this.wwwLoaderItem.onComplete += this.loaderComplete;

		this.wwwLoaderItem.Loader(path, loaderTypeEnum, version);
	}

	/// <summary>
	/// 销毁对象
	/// </summary>
	/// <param name="destory">If set to <c>true</c> destory.</param>
	public void UnLoader(bool destory = true) {
		if (this.wwwLoaderItem == null) return;

		this.wwwLoaderItem.onProgress -= this.loaderProgress;
		this.wwwLoaderItem.onError -= this.loaderError;
		this.wwwLoaderItem.onComplete -= this.loaderComplete;

		// 销毁自己
		this.wwwLoaderItem.UnLoaderThis();
		// 销毁对象
		if(destory) this.wwwLoaderItem.UnLoader();

	}
}
