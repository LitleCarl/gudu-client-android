using System;
using Android.Content;
using Android.Preferences;
using System.Reactive.Linq;
using System.Collections.Generic;

namespace Gudu
{
	public class SharedPreferenceSignal<T>:Java.Lang.Object, ISharedPreferencesOnSharedPreferenceChangeListener
	{
		private static List<object> spSignalInstances;

		static SharedPreferenceSignal(){
			spSignalInstances = new List<object>();
		}

		IObserver<T> subscriber;
		String key;

		public static IObservable<R> rac_listen_for_key<R>(String key){
			SharedPreferenceSignal<R> instance = new SharedPreferenceSignal<R>();
			spSignalInstances.Add (instance);
			instance.key = key;
			ISharedPreferences prefs = Tool.sharedInstance;
			prefs.RegisterOnSharedPreferenceChangeListener (instance);
			IObservable<R> signal = Observable.Create<R> (
				(subscriber) => {
					instance.subscriber = subscriber;
					Type typeParameterType = typeof(R);
					if (typeParameterType == typeof(String)) {
						subscriber.OnNext ((R)((object) (prefs.GetString (key, null))));
					}
					else if (typeParameterType == typeof(bool)) {
						subscriber.OnNext ((R)((object) (prefs.GetBoolean (key, false))));
					}
					else if (typeParameterType == typeof(int)) {
						subscriber.OnNext ((R)((object) (prefs.GetInt (key, 0))));
					}
					else if (typeParameterType == typeof(float)) {
						subscriber.OnNext ((R)((object) (prefs.GetFloat (key, 0))));
					}
					return () => {
						prefs.UnregisterOnSharedPreferenceChangeListener(instance);
						spSignalInstances.Remove(instance);
					};
				}
			);

			return signal;
		}

		// 构造函数
		public SharedPreferenceSignal ()
		{
		}

		public  void OnSharedPreferenceChanged (ISharedPreferences sharedPreferences, string key){
			if (key != this.key) {
				return;
			}
			Type typeParameterType = typeof(T);
			if (typeParameterType == typeof(String)) {
				subscriber.OnNext ((T)((object) (sharedPreferences.GetString (key, null))));
			}
			else if (typeParameterType == typeof(bool)) {
				subscriber.OnNext ((T)((object) (sharedPreferences.GetBoolean (key, false))));
			}
			else if (typeParameterType == typeof(int)) {
				subscriber.OnNext ((T)((object) (sharedPreferences.GetInt (key, 0))));
			}
			else if (typeParameterType == typeof(float)) {
				subscriber.OnNext ((T)((object) (sharedPreferences.GetFloat (key, 0))));
			}
		}
//		public override IntPtr Handle {
//			get;
//		}
//		public override void Dispose (){
//			
//		}
	}
}

