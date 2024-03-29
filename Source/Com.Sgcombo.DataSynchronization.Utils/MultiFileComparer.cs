﻿////////////////////////////////////////////////////////////////////////////
//	Copyright 2016 : Vladimir Novick    https://www.linkedin.com/in/vladimirnovick/  
//
//    NO WARRANTIES ARE EXTENDED. USE AT YOUR OWN RISK. 
//
// To contact the author with suggestions or comments, use  :vlad.novick@gmail.com
//
////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Com.SGcombo.DataSynchronization.Utils
{
    public class MultiFileComparer<T>
    {
        protected ComponentLibrary<T> _ComponentList = null;

        public MultiFileComparer(ComponentLibrary<T> _componentList)
        {
            _ComponentList = _componentList;
        }
        
        public int Compare(FileInfo file1, FileInfo file2)
        {
            int result = 0;
            if (_ComponentList == null || _ComponentList.Components.Count <= 0) return result;
            foreach (IFileComparer _comparer in _ComponentList.Components)
            {
                result = result + _comparer.Compare(file1, file2);
            }
            return result;
        }
    }
}
