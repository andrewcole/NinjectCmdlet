using System.Management.Automation;
using Ninject;
using Ninject.Modules;

namespace Illallangi
{
    [Cmdlet(VerbsCommon.Get, NinjectCmdlet<T1>.Null)]
    public abstract class NinjectCmdlet<T1> : PSCmdlet
        where T1 : INinjectModule, new()
    {
        #region Fields

        private const string Null = @"Null";

        private INinjectModule currentModule1;

        private StandardKernel currentKernel;

        #endregion

        #region Properties

        private INinjectModule Module1
        {
            get
            {
                return this.currentModule1 ?? (this.currentModule1 = new T1());
            }
        }

        private StandardKernel Kernel
        {
            get
            {
                return this.currentKernel ?? (this.currentKernel = new StandardKernel(this.Module1));
            }
        }

        #endregion

        #region Methods

        protected T Get<T>()
        {
            return this.Kernel.Get<T>();
        }

        #endregion
    }

    [Cmdlet(VerbsCommon.Get, NinjectCmdlet<T1, T2>.Null)]
    public abstract class NinjectCmdlet<T1, T2> : PSCmdlet
        where T1 : INinjectModule, new()
        where T2 : INinjectModule, new()
    {
        #region Fields

        protected const string Null = @"Null";

        private INinjectModule currentModule1;

        private INinjectModule currentModule2;

        private StandardKernel currentKernel;

        #endregion

        #region Properties

        private INinjectModule Module1
        {
            get
            {
                return this.currentModule1 ?? (this.currentModule1 = new T1());
            }
        }

        private INinjectModule Module2
        {
            get
            {
                return this.currentModule2 ?? (this.currentModule2 = new T2());
            }
        }

        private StandardKernel Kernel
        {
            get
            {
                return this.currentKernel ?? (this.currentKernel = new StandardKernel(this.Module1, this.Module2));
            }
        }

        #endregion

        #region Methods

        protected T Get<T>()
        {
            return this.Kernel.Get<T>();
        }

        #endregion
    }


    [Cmdlet(VerbsCommon.Get, NinjectCmdlet<T1, T2, T3>.Null)]
    public abstract class NinjectCmdlet<T1, T2, T3> : PSCmdlet
        where T1 : INinjectModule, new()
        where T2 : INinjectModule, new()
        where T3 : INinjectModule, new()
    {
        #region Fields

        protected const string Null = @"Null";

        private INinjectModule currentModule1;

        private INinjectModule currentModule2;

        private INinjectModule currentModule3;

        private StandardKernel currentKernel;

        #endregion

        #region Properties

        private INinjectModule Module1
        {
            get
            {
                return this.currentModule1 ?? (this.currentModule1 = new T1());
            }
        }

        private INinjectModule Module2
        {
            get
            {
                return this.currentModule2 ?? (this.currentModule2 = new T2());
            }
        }

        private INinjectModule Module3
        {
            get
            {
                return this.currentModule3 ?? (this.currentModule3 = new T3());
            }
        }

        private StandardKernel Kernel
        {
            get
            {
                return this.currentKernel ?? (this.currentKernel = new StandardKernel(this.Module1, this.Module2, this.Module3));
            }
        }

        #endregion

        #region Methods

        protected T Get<T>()
        {
            return this.Kernel.Get<T>();
        }

        #endregion
    }


}