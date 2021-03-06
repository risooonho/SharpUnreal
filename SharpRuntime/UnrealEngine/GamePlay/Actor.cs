﻿using System;
using System.Runtime.CompilerServices;

namespace UnrealEngine
{
    public class Actor : UObject
    {
        public Actor()
        {
        }

        public Actor(IntPtr handler)
        {
            NativeHandler = handler;
        }

        public virtual void UnRegister()
        {
            NativeHandler = IntPtr.Zero;
            if (m_Root != null)
            {
                m_Root.NativeHandler = IntPtr.Zero;
                m_Root = null;
            }

            if (m_Sequencer != null)
            {
                m_Sequencer.NativeHandler = IntPtr.Zero;
                m_Sequencer = null;
            }
        }

        public bool HasTag(string tag)
        {
            return _HasTag(NativeHandler, tag);
        }

        public void AddTag(string tag)
        {
            _AddTag(NativeHandler, tag);
        }

        public void RemoveTag(string tag)
        {
            _RemoveTag(NativeHandler, tag);
        }

        /// <summary>
        /// 设置跟获取是否隐藏
        /// </summary>
        public bool HiddenInGame
        {
            get { return _GetHiddenInGame(NativeHandler); }
            set { _SetHiddenInGame(NativeHandler, value); }
        }

        /// <summary>
        /// 获取场景的根组件
        /// </summary>
        private SceneComponent m_Root;
        public SceneComponent Root
        {
            get
            {
                if (m_Root == null)
                {
                    var handler = _GetSceneComponent(NativeHandler);
                    if (handler == null)
                    {
                        m_Root = null;
                    }
                    else
                    {
                        m_Root = new SceneComponent();
                        m_Root.NativeHandler = handler;
                    }
                }
                return m_Root;
            }
            set { _SetSceneComponent(NativeHandler, value.NativeHandler); }
        }

        private Sequencer m_Sequencer;
        /// <summary>
        /// 获取这个Actor上的Sequencer
        /// </summary>
        public Sequencer Sequencer
        {
            get
            {
                if (m_Sequencer == null)
                {
                    var handler = _GetSequencer(NativeHandler);
                    if (handler.ToInt64() == 0)
                    {
                        return null;
                    }
                    m_Sequencer = new Sequencer();
                    m_Sequencer.NativeHandler = handler;
                }
                return m_Sequencer;
            }
        }

        /// <summary>
        /// 获取脚本上的C#组件
        /// </summary>
        /// <returns></returns>
        public ActorComponent GetMonoComponent()
        {
            return _GetMonoComponent(NativeHandler);
        }

        /// <summary>
        /// 获取脚本上的C#组件
        /// </summary>
        /// <returns></returns>
        public ActorComponent GetMonoComponentByTag(string tag)
        {
            return _GetMonoComponentByTag(NativeHandler, tag);
        }

        /// <summary>
        /// 查找Actor上的指定类型的组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : ActorComponent, new()
        {
            IntPtr handler = _GetComponent(NativeHandler, typeof(T).Name);

            if (handler.ToInt64() == 0)
            {
                return null;
            }

            T ret = new T();
            ret.NativeHandler = handler;

            return ret;
        }

        /// <summary>
        /// 根据Tag查找Actor指定类型的组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <returns></returns>
        public T GetComponentByTag<T>(string tag) where T : ActorComponent, new()
        {
            var handler = _GetComponentByTag(NativeHandler, typeof(T).Name, tag);
            if (handler.ToInt64() == 0)
            {
                return null;
            }
            T ret = new T();
            ret.NativeHandler = handler;
            return ret;
        }

        /// <summary>
        /// 销毁这个Actor
        /// </summary>
        public void Destroy()
        {
            _Destroy(NativeHandler);
            NativeHandler = IntPtr.Zero;
        }

        /// <summary>
        /// 获取Actor名字
        /// </summary>
        public string Name
        {
            get { return _GetName(NativeHandler); }
        }

        public IntProperty FindIntProperty(string name)
        {
            var handler = _FindIntProperty(NativeHandler, name);
            if (handler.ToInt64() == 0)
            {
                return null;
            }

            var property = new IntProperty();
            property.NativeHandler = handler;
            property.ActorHandler = NativeHandler;

            return property;
        }

        public FloatProperty FindFloatProperty(string name)
        {
            var handler = _FindFloatProperty(NativeHandler, name);
            if (handler.ToInt64() == 0)
            {
                return null;
            }

            var property = new FloatProperty();
            property.NativeHandler = handler;
            property.ActorHandler = NativeHandler;

            return property;
        }

        public StringProperty FindStringProperty(string name)
        {
            var handler = _FindStringProperty(NativeHandler, name);
            if (handler.ToInt64() == 0)
            {
                return null;
            }

            var property = new StringProperty();
            property.NativeHandler = handler;
            property.ActorHandler = NativeHandler;

            return property;
        }

        public VectorProperty FindVectorProperty(string name)
        {
            var handler = _FindVectorProperty(NativeHandler, name);
            if (handler.ToInt64() == 0)
            {
                return null;
            }

            var property = new VectorProperty();
            property.NativeHandler = handler;
            property.ActorHandler = NativeHandler;

            return property;
        }

        public RotatorProperty FindRotatorProperty(string name)
        {
            var handler = _FindRotatorProperty(NativeHandler, name);
            if (handler.ToInt64() == 0)
            {
                return null;
            }

            var property = new RotatorProperty();
            property.NativeHandler = handler;
            property.ActorHandler = NativeHandler;

            return property;
        }

        public QuatProperty FindQuatProperty(string name)
        {
            var handler = _FindQuatProperty(NativeHandler, name);
            if (handler.ToInt64() == 0)
            {
                return null;
            }

            var property = new QuatProperty();
            property.NativeHandler = handler;
            property.ActorHandler = NativeHandler;

            return property;
        }

        public TransformProperty FindTransformProperty(string name)
        {
            var handler = _FindTransformProperty(NativeHandler, name);
            if (handler.ToInt64() == 0)
            {
                return null;
            }

            var property = new TransformProperty();
            property.NativeHandler = handler;
            property.ActorHandler = NativeHandler;

            return property;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static bool _HasTag(IntPtr handler, string tag);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void _AddTag(IntPtr handler, string tag);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void _RemoveTag(IntPtr handler, string tag);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _GetSequencer(IntPtr handler);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static bool _GetHiddenInGame(IntPtr handler);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void _SetHiddenInGame(IntPtr handler, bool value);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _GetSceneComponent(IntPtr handler);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void _SetSceneComponent(IntPtr handler, IntPtr value);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static ActorComponent _GetMonoComponent(IntPtr handler);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static ActorComponent _GetMonoComponentByTag(IntPtr handler, string tag); 
         [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _GetComponent(IntPtr handler, string type);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _GetComponentByTag(IntPtr handler, string type, string tag);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void _Destroy(IntPtr handler);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static string _GetName(IntPtr handler);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _FindIntProperty(IntPtr handler, string name);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _FindFloatProperty(IntPtr handler, string name);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _FindStringProperty(IntPtr handler, string name);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _FindVectorProperty(IntPtr handler, string name);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _FindRotatorProperty(IntPtr handler, string name);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _FindQuatProperty(IntPtr handler, string name);
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static IntPtr _FindTransformProperty(IntPtr handler, string name);
    }
}
