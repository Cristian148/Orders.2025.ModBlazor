using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace RuFramework.Config
{
    #region Converter String Array to String

    /* This is required for the converter, here using the example of culture/language
     
    private string instaledCultur;
    public static string[]? ListOfInstaledCultur;

    public void UpdateListofInstaledCultur()
    {
        int NumOfInstaledCultur = Installedlanguages.Length;

        ListOfInstaledCultur = new string[NumOfInstaledCultur];
        for (int i = 0; i <= NumOfInstaledCultur - 1; i++)
        {
            ListOfInstaledCultur[i] = Installedlanguages[i];
        }
    }
    */
    public class InstaledCulturConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true means show a combobox
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            //true will limit to list. false will show the list, but allow free-form entry
            return true;
        }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(AppSettings.ListOfInstaledCultur);
        }
    }
    #endregion
}

