// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.IfcRail.PresentationAppearanceResource;
using Xbim.IfcRail.GeometryResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.IfcRail.GeometricModelResource;
//## Custom using statements
//##


namespace Xbim.IfcRail.GeometricModelResource
{
	[ExpressType("IfcTessellatedFaceSet", 1299)]
	// ReSharper disable once PartialTypeWithSinglePart
	public abstract partial class @IfcTessellatedFaceSet : IfcTessellatedItem, IfcBooleanOperand, IEquatable<@IfcTessellatedFaceSet>
	{

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcTessellatedFaceSet(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcCartesianPointList3D _coordinates;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
		public IfcCartesianPointList3D @Coordinates 
		{ 
			get 
			{
				if(_activated) return _coordinates;
				Activate();
				return _coordinates;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _coordinates = v, _coordinates, value,  "Coordinates", 1);
			} 
		}	
		#endregion


		#region Derived attributes
		[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
		public IfcDimensionCount @Dim 
		{
			get 
			{
				//## Getter for Dim
                return 3;
                //##
			}
		}

		#endregion

		#region Inverse attributes
		[InverseProperty("MappedTo")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 0 }, new int [] { 1 }, 4)]
		public IEnumerable<IfcIndexedColourMap> @HasColours 
		{ 
			get 
			{
				return Model.Instances.Where<IfcIndexedColourMap>(e => Equals(e.MappedTo), "MappedTo", this);
			} 
		}
		[InverseProperty("MappedTo")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int [] { 0 }, new int [] { -1 }, 5)]
		public IEnumerable<IfcIndexedTextureMap> @HasTextures 
		{ 
			get 
			{
				return Model.Instances.Where<IfcIndexedTextureMap>(e => Equals(e.MappedTo), "MappedTo", this);
			} 
		}
		#endregion

		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_coordinates = (IfcCartesianPointList3D)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcTessellatedFaceSet other)
	    {
	        return this == other;
	    }
        #endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}