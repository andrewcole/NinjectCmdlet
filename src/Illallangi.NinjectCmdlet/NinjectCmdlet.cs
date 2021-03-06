﻿using System;
using System.Management.Automation;

using Ninject;
using Ninject.Modules;

namespace Illallangi
{
    [Cmdlet(VerbsCommon.Get, NinjectCmdlet<Tmodule>.Null)]
    public abstract class NinjectCmdlet<Tmodule> : PSCmdlet
        where Tmodule : INinjectModule, new()
    {
        #region Fields

        protected const string Null = @"Null";

        private readonly INinjectSettings currentNinjectSettings;

        private INinjectModule currentModule;

        private StandardKernel currentKernel;

        #endregion

        #region Constructor

        protected NinjectCmdlet(INinjectSettings ninjectSettings = null)
        {
            this.currentNinjectSettings = ninjectSettings ?? new NinjectSettings();
        }

        #endregion

        #region Properties

        private INinjectSettings NinjectSettings
        {
            get
            {
                return this.currentNinjectSettings;
            }
        }

        private INinjectModule Module
        {
            get
            {
                return this.currentModule ?? (this.currentModule = this.GetModule());
            }
        }

        private StandardKernel Kernel
        {
            get
            {
                return this.currentKernel
                       ?? (this.currentKernel = new StandardKernel(this.NinjectSettings, this.Module));
            }
        }

        #endregion

        #region Methods

        protected T Get<T>()
        {
            return this.Kernel.Get<T>();
        }

        protected virtual INinjectModule GetModule()
        {
            return new Tmodule();
        }

        #endregion
    }
}