using System;
using System.Collections.Generic;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using MyMvvmCrossApp.Core.ViewModels.Main;

namespace MyMvvmCrossApp.Droid.TemplateSelectors
{
    public class AnimalsTemplateSelector : IMvxTemplateSelector
    {
        private readonly Dictionary<Type, int> _itemsTypeDictionary = new Dictionary<Type, int>
        {
            [typeof(DogViewModel)] = Resource.Layout.dog,
            [typeof(CatViewModel)] = Resource.Layout.cat
        };

        public int ItemTemplateId { get; set; }

        public int GetItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }

        public int GetItemViewType(object forItemObject)
        {
            return _itemsTypeDictionary[forItemObject.GetType()];
        }
    }
}
