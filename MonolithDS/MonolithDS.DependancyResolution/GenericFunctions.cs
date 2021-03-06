﻿using MonolithDS.Image;
using Ninject.Modules;

namespace MonolithDS.DependancyResolution
{
    public class GenericFunctions : NinjectModule
    {
        public override void Load()
        {
            Bind<IImageHelper>().To<ImageHelper>();
        }
    }
}
