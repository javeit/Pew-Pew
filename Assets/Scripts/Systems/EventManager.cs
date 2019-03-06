using System;
using System.Collections.Generic;
using UnityEngine;

namespace PewPew {

    public class EventManager {

        private static List<EventHandler> _broadcasts;
        private static List<EventHandler> _requests;

        public static void Init() {

            _broadcasts = new List<EventHandler>();
            _requests = new List<EventHandler>();
        }

        public static void Clean() {

            Init();
        }

        // Broadcasts are events which don't return any value and which any script can listen to or trigger (provided they know the correct string identifier and parameter list)
        #region broadcasts

        /// <summary>
        /// Adds a listener to the broadcast with the given name
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="handler">Handler.</param>
        public static void AddBroadcastListener(string broadcastName, Action handler) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action);

            if (existingBroadcast != null)
                existingBroadcast.handler = Delegate.Combine(existingBroadcast.handler, handler);
            else
                _broadcasts.Add(new EventHandler(broadcastName, handler));
        }

        /// <summary>
        /// Adds a listener to the broadcast with the given name
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="TParam">The 1st type parameter.</typeparam>
        public static void AddBroadcastListener<TParam>(string broadcastName, Action<TParam> handler) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action<TParam>);

            if (existingBroadcast != null)
                existingBroadcast.handler = Delegate.Combine(existingBroadcast.handler, handler);
            else
                _broadcasts.Add(new EventHandler(broadcastName, handler));
        }

        /// <summary>
        /// Adds a listener to the broadcast with the given name
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="TParam1">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam2">The 2nd type parameter.</typeparam>
        public static void AddBroadcastListener<TParam1, TParam2>(string broadcastName, Action<TParam1, TParam2> handler) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action<TParam1, TParam2>);

            if (existingBroadcast != null)
                existingBroadcast.handler = Delegate.Combine(existingBroadcast.handler, handler);
            else
                _broadcasts.Add(new EventHandler(broadcastName, handler));
        }

        /// <summary>
        /// Adds a listener to the broadcast with the given name
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="TParam1">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam2">The 2nd type parameter.</typeparam>
        /// <typeparam name="TParam3">The 3rd type parameter.</typeparam>
        public static void AddBroadcastListener<TParam1, TParam2, TParam3>(string broadcastName, Action<TParam1, TParam2, TParam3> handler) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action<TParam1, TParam2, TParam3>);

            if (existingBroadcast != null)
                existingBroadcast.handler = Delegate.Combine(existingBroadcast.handler, handler);
            else
                _broadcasts.Add(new EventHandler(broadcastName, handler));
        }

        /// <summary>
        /// Removes a listener to the broadcast with the given name
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="handler">Handler.</param>
        public static void RemoveBroadcastListener(string broadcastName, Action handler) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action);

            if(existingBroadcast != null) {

                existingBroadcast.handler = Delegate.Remove(existingBroadcast.handler, handler);

                if (existingBroadcast.handler == null)
                    _broadcasts.Remove(existingBroadcast);
            }
        }

        /// <summary>
        /// Removes a listener to the broadcast with the given name
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="TParam">The 1st type parameter.</typeparam>
        public static void RemoveBroadcastListener<TParam>(string broadcastName, Action<TParam> handler) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action<TParam>);

            if (existingBroadcast != null) {

                existingBroadcast.handler = Delegate.Remove(existingBroadcast.handler, handler);

                if (existingBroadcast.handler == null)
                    _broadcasts.Remove(existingBroadcast);
            }
        }

        /// <summary>
        /// Removes a listener to the broadcast with the given name
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="TParam1">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam2">The 2nd type parameter.</typeparam>
        public static void RemoveBroadcastListener<TParam1, TParam2>(string broadcastName, Action<TParam1, TParam2> handler) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action<TParam1, TParam2>);

            if (existingBroadcast != null) {

                existingBroadcast.handler = Delegate.Remove(existingBroadcast.handler, handler);

                if (existingBroadcast.handler == null)
                    _broadcasts.Remove(existingBroadcast);
            }
        }

        /// <summary>
        /// Removes a listener to the broadcast with the given name
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="TParam1">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam2">The 2nd type parameter.</typeparam>
        public static void RemoveBroadcastListener<TParam1, TParam2, TParam3>(string broadcastName, Action<TParam1, TParam2, TParam3> handler) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action<TParam1, TParam2, TParam3>);

            if (existingBroadcast != null) {

                existingBroadcast.handler = Delegate.Remove(existingBroadcast.handler, handler);

                if (existingBroadcast.handler == null)
                    _broadcasts.Remove(existingBroadcast);
            }
        }

        /// <summary>
        /// Triggers the broadcast with the given name
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        public static void TriggerBroadcast(string broadcastName) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action);

            if(existingBroadcast != null)
                (existingBroadcast.handler as Action).Invoke();
        }

        /// <summary>
        /// Triggers the broadcast with the given name, and the given single parameter
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="param1">Param1.</param>
        /// <typeparam name="TParam">The 1st type parameter.</typeparam>
        public static void TriggerBroadcast<TParam>(string broadcastName, TParam param1) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action<TParam>);

            if (existingBroadcast != null)
                (existingBroadcast.handler as Action<TParam>).Invoke(param1);
        }

        /// <summary>
        /// Triggers the broadcast with the given name, and the given two parameters
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="param1">Param1.</param>
        /// <param name="param2">Param2.</param>
        /// <typeparam name="TParam1">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam2">The 2nd type parameter.</typeparam>
        public static void TriggerBroadcast<TParam1, TParam2>(string broadcastName, TParam1 param1, TParam2 param2) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action<TParam1, TParam2>);

            if (existingBroadcast != null)
                (existingBroadcast.handler as Action<TParam1, TParam2>).Invoke(param1, param2);
        }

        /// <summary>
        /// Triggers the broadcast with the given name, and the given three parameters
        /// </summary>
        /// <param name="broadcastName">Broadcast name.</param>
        /// <param name="param1">Param1.</param>
        /// <param name="param2">Param2.</param>
        /// <param name="param3">Param3.</param>
        /// <typeparam name="TParam1">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam2">The 2nd type parameter.</typeparam>
        /// <typeparam name="TParam3">The 3rd type parameter.</typeparam>
        public static void TriggerBroadcast<TParam1, TParam2, TParam3>(string broadcastName, TParam1 param1, TParam2 param2, TParam3 param3) {

            EventHandler existingBroadcast = _broadcasts.Find((h) => string.Equals(h.eventName, broadcastName) && h.handler is Action<TParam1, TParam2, TParam3>);

            if (existingBroadcast != null)
                (existingBroadcast.handler as Action<TParam1, TParam2, TParam3>).Invoke(param1, param2, param3);
        }

        #endregion

        // Requests are events which return a single value of any type, which only one script can register, while any script can trigger, causing the request to return the value 
        // (provided they know the correct string identifier and parameter list)
        #region requests

        /// <summary>
        /// Adds a request with <paramref name="requestName"/> as a label, which returns a value of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="requestName">Request name.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void AddRequest<T>(string requestName, Func<T> handler) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<T>);

            if (existingRequest != null)
                Debug.LogErrorFormat("EventManager already contains a request labeled '{0}' of type '{1}'", requestName, typeof(T));
            else
                _requests.Add(new EventHandler(requestName, handler));
        }

        /// <summary>
        /// Adds a request with <paramref name="requestName"/> as a label, which returns a value of type <typeparamref name="T"/>
        /// with the parameter <typeparamref name="TParam"/>
        /// </summary>
        /// <param name="requestName">Request name.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam">The 2nd type parameter.</typeparam>
        public static void AddRequest<T, TParam>(string requestName, Func<TParam, T> handler) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<TParam, T>);

            if (existingRequest != null)
                Debug.LogErrorFormat("EventManager already contains a request labeled '{0}' of type '{1}' with Parameter '{2}'", requestName, typeof(T), typeof(TParam));
            else
                _requests.Add(new EventHandler(requestName, handler));
        }

        /// <summary>
        /// Adds a request with <paramref name="requestName"/> as a label, which returns a value of type <typeparamref name="T"/>
        /// with the parameters <typeparamref name="TParam1"/> and <typeparamref name="TParam2"/>
        /// </summary>
        /// <param name="requestName">Request name.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam1">The 2nd type parameter.</typeparam>
        /// <typeparam name="TParam2">The 3rd type parameter.</typeparam>
        public static void AddRequest<T, TParam1, TParam2>(string requestName, Func<TParam1, TParam2, T> handler) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<TParam1, TParam2, T>);

            if (existingRequest != null)
                Debug.LogErrorFormat("EventManager already contains a request labeled '{0}' of type '{1}' with Parameters '{2}' and '{3}'", requestName, typeof(T), typeof(TParam1), typeof(TParam2));
            else
                _requests.Add(new EventHandler(requestName, handler));
        }

        /// <summary>
        /// Adds a request with <paramref name="requestName"/> as a label, which returns a value of type <typeparamref name="T"/>
        /// with the parameters <typeparamref name="TParam1"/>, <typeparamref name="TParam2"/>, and <typeparamref name="TParam3"/>
        /// </summary>
        /// <param name="requestName">Request name.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam1">The 2nd type parameter.</typeparam>
        /// <typeparam name="TParam2">The 3rd type parameter.</typeparam>
        /// <typeparam name="TParam3">The 4th type parameter.</typeparam>
        public static void AddRequest<T, TParam1, TParam2, TParam3>(string requestName, Func<TParam1, TParam2, TParam3, T> handler) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<TParam1, TParam2, TParam3, T>);

            if (existingRequest != null)
                Debug.LogErrorFormat("EventManager already contains a request labeled '{0}' of type '{1}' with Parameters '{2}', '{3}', and '{4}'", requestName, typeof(T), typeof(TParam1), typeof(TParam2), typeof(TParam3));
            else
                _requests.Add(new EventHandler(requestName, handler));
        }

        /// <summary>
        /// Removes a request with <paramref name="requestName"/> as a label, which returns a value of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="requestName">Request name.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void RemoveRequest<T>(string requestName) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<T>);

            if (existingRequest != null)
                _requests.Add(existingRequest);
        }

        /// <summary>
        /// Removes a request with <paramref name="requestName"/> as a label, which returns a value of type <typeparamref name="T"/>
        /// with the parameter <typeparamref name="TParam"/>
        /// </summary>
        /// <param name="requestName">Request name.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam">The 2nd type parameter.</typeparam>
        public static void RemoveRequest<T, TParam>(string requestName) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<TParam, T>);

            if (existingRequest != null)
                _requests.Add(existingRequest);
        }

        /// <summary>
        /// Removes a request with <paramref name="requestName"/> as a label, which returns a value of type <typeparamref name="T"/>
        /// with the parameters <typeparamref name="TParam1"/> and <typeparamref name="TParam2"/>
        /// </summary>
        /// <param name="requestName">Request name.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam1">The 2nd type parameter.</typeparam>
        /// <typeparam name="TParam2">The 3rd type parameter.</typeparam>
        public static void RemoveRequest<T, TParam1, TParam2>(string requestName) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<TParam1, TParam2, T>);

            if (existingRequest != null)
                _requests.Add(existingRequest);
        }

        /// <summary>
        /// Removes a request with <paramref name="requestName"/> as a label, which returns a value of type <typeparamref name="T"/>
        /// with the parameters <typeparamref name="TParam1"/>, <typeparamref name="TParam2"/>, and <typeparamref name="TParam3"/>
        /// </summary>
        /// <param name="requestName">Request name.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam1">The 2nd type parameter.</typeparam>
        /// <typeparam name="TParam2">The 3rd type parameter.</typeparam>
        /// <typeparam name="TParam3">The 4th type parameter.</typeparam>
        public static void RemoveRequest<T, TParam1, TParam2, TParam3>(string requestName) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<TParam1, TParam2, TParam3, T>);

            if (existingRequest != null)
                _requests.Add(existingRequest);
        }

        /// <summary>
        /// Returns the object of type <typeparamref name="T"/> associated with the request labeled <paramref name="requestName"/>
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="requestName">Request name.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T Request<T>(string requestName) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<T>);

            if (existingRequest != null) {

                Func<T> requestHandler = existingRequest.handler as Func<T>;

                return requestHandler();

            } else {

                throw new ArgumentNullException(string.Format("Request not found: {0} - {1}", requestName, typeof(T)));
            }
        }

        /// <summary>
        /// Returns the object of type <typeparamref name="T"/> associated with the request labeled <paramref name="requestName"/>
        /// given the parameter <paramref name="param"/>
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="requestName">Request name.</param>
        /// <param name="param">Parameter.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam">The 2nd type parameter.</typeparam>
        public static T Request<T, TParam>(string requestName, TParam param) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<TParam, T>);

            if (existingRequest != null) {

                Func<TParam, T> requestHandler = existingRequest.handler as Func<TParam, T>;

                return requestHandler(param);

            } else {

                throw new ArgumentNullException(string.Format("Request not found: {0} - {1}, {2}", requestName, typeof(T), typeof(TParam)));
            }
        }

        /// <summary>
        /// Returns the object of type <typeparamref name="T"/> associated with the request labeled <paramref name="requestName"/>
        /// given the parameters <paramref name="param1"/> and <paramref name="param2"/>
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="requestName">Request name.</param>
        /// <param name="param1">Param1.</param>
        /// <param name="param2">Param2.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam1">The 2nd type parameter.</typeparam>
        /// <typeparam name="TParam2">The 3rd type parameter.</typeparam>
        public static T Request<T, TParam1, TParam2>(string requestName, TParam1 param1, TParam2 param2) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<TParam1, TParam2, T>);

            if (existingRequest != null) {

                Func<TParam1, TParam2, T> requestHandler = existingRequest.handler as Func<TParam1, TParam2, T>;

                return requestHandler(param1, param2);

            } else {

                throw new ArgumentNullException(string.Format("Request not found: {0} - {1}, {2}, {3}", requestName, typeof(T), typeof(TParam1), typeof(TParam2)));
            }
        }

        /// <summary>
        /// Returns the object of type <typeparamref name="T"/> associated with the request labeled <paramref name="requestName"/>
        /// given the parameters <paramref name="param1"/>, <paramref name="param2"/>, <paramref name="param3"/>
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="requestName">Request name.</param>
        /// <param name="param1">Param1.</param>
        /// <param name="param2">Param2.</param>
        /// <param name="param3">Param3.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TParam1">The 2nd type parameter.</typeparam>
        /// <typeparam name="TParam2">The 3rd type parameter.</typeparam>
        /// <typeparam name="TParam3">The 4th type parameter.</typeparam>
        public static T Request<T, TParam1, TParam2, TParam3>(string requestName, TParam1 param1, TParam2 param2, TParam3 param3) {

            EventHandler existingRequest = _requests.Find((h) => string.Equals(h.eventName, requestName) && h.handler is Func<TParam1, TParam2, TParam3, T>);

            if (existingRequest != null) {

                Func<TParam1, TParam2, TParam3, T> requestHandler = existingRequest.handler as Func<TParam1, TParam2, TParam3, T>;

                return requestHandler(param1, param2, param3);

            } else {

                throw new ArgumentNullException(string.Format("Request not found: {0} - {1}, {2}, {3}, {4}", requestName, typeof(T), typeof(TParam1), typeof(TParam2), typeof(TParam3)));
            }
        }

        #endregion
    }

    public class EventHandler {

        public string eventName;

        public Delegate handler;

        public EventHandler(string eventName, Delegate handler) {

            this.eventName = eventName;
            this.handler = handler;
        }
    }
}