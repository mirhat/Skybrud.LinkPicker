﻿using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Interfaces;

namespace Skybrud.LinkPicker.Grid.Values {
    
    public class GridControlLinkPickerValue : LinkPickerList, IGridControlValue {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent control.
        /// </summary>
        public GridControl Control { get; private set; }

        /// <summary>
        /// Gets whether the link picker list is valid (alias of <see cref="LinkPickerList.HasItems"/>).
        /// </summary>
        [JsonIgnore]
        public override bool IsValid {
            get { return HasItems; }
        }

        #endregion

        #region Constructors

        protected GridControlLinkPickerValue(GridControl control, JObject obj) : base(obj) {
            Control = control;
        }

        #endregion

        #region Member methods

        public string GetSearchableText() {

            if (!IsValid) return "";

            StringBuilder sb = new StringBuilder();
                
            // Append the title of the control
            sb.AppendLine(Title);
            sb.AppendLine();

            // Append the name (link text) of each item
            foreach (var item in Items) {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().Trim();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="GridControlLinkPickerValue"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="control">The parent control.</param>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        public static GridControlLinkPickerValue Parse(GridControl control, JObject obj) {
            return control == null ? null : new GridControlLinkPickerValue(control, obj ?? new JObject());
        }

        #endregion

    }

}