using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_EF
{
   
        [MetadataType(typeof(CROP.CropsMetadata))]

        public partial class CROP

        {

            private sealed class CropsMetadata

            {

                [Display(Name = "Crop Name")]
                public string Name { get; set; }

                [Display(Name = "Description")]
                public string Description { get; set; }

                [Display(Name = "Type of Crop")]
                public string Type { get; set; }

                [Display(Name = "Days Until Harvest")]
                public int DaysTillHarvest { get; set; }

                [Display(Name = "Growing Season")]
                public string Season { get; set; }

                [Display(Name = "Shelf Life")]
                public int ShelfLife { get; set; }

                [Display(Name = "Market Value")]
                public double MarketValue { get; set; }

                [Display(Name = "Amount of Water Needed")]
                public string WaterAmount { get; set; }

                [Display(Name = "Rotation Recommondations")]
                public string CropRotationRecom { get; set; }

                [Display(Name = "Recommended Harvest Techniques")]
                public string HarvestTechniques { get; set; }


            }

        }

    [MetadataType(typeof(CATEGORY.CategoryMetadata))]

    public partial class CATEGORY

    {

        private sealed class CategoryMetadata

        {

            [Display(Name = "Category")]
            public string Name { get; set; }

        }

    }

    [MetadataType(typeof(CROP_WATER_STATUS.WaterMetadata))]

    public partial class CROP_WATER_STATUS

    {

        private sealed class WaterMetadata

        {

            [Display(Name = "Water Status")]
            public string Name { get; set; }

        }

    }
    [MetadataType(typeof(CUSTOMER.CustMetadata))]

    public partial class CUSTOMER

    {

        private sealed class CustMetadata

        {

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

        }
    }
    /*[MetadataType(typeof(CUSTOMERROSTER.CustRMetadata))]

    public partial class CUSTOMERROSTER

    {

        private sealed class CustRMetadata

        {

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

        }
    }
    [MetadataType(typeof(EMPLOYEE.EmpMetadata))]

    public partial class EMPLOYEE

    {

        private sealed class EmpMetadata

        {

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Date of Birth")]
            public string DateofBirth { get; set; }

            [Display(Name = "Certifications")]
            public string Certifications { get; set; }

            [Display(Name = "Allergies")]
            public string Allergies { get; set; }

        }
    }*/

    /*[MetadataType(typeof(EQUIPMENT.EquipMetadata))]

    public partial class EQUIPMENT

    {

        private sealed class EquipMetadata

        {

            [Display(Name = "Equipment Name")]
            public string Name { get; set; }

            [Display(Name = "Type")]
            public string Type { get; set; }

            [Display(Name = "Description")]
            public string Description { get; set; }


        }
    }*/
    [MetadataType(typeof(FARM.FarmMetadata))]

    public partial class FARM

    {

        private sealed class FarmMetadata

        {

            [Display(Name = "Farm Name")]
            public string Name { get; set; }

            [Display(Name = "Zip Code")]
            public int ZipCode { get; set; }

        }
    }
    /*[MetadataType(typeof(INVENTORY.InventMetadata))]

    public partial class INVENTORY

    {

        private sealed class InventMetadata

        {

            [Display(Name = "Quantity")]
            public string Quantity { get; set; }
        }*/

    [MetadataType (typeof(PLOT.PlotMetadata))]

    public partial class PLOT

    {

        private sealed class PlotMetadata

        {

            [Display(Name = "Plot Name")]
            public string Name { get; set; }

            [Display(Name = "Plot History")]
            public string History { get; set; }

            [Display(Name = "Date Planted")]
            public DateTime DatePlantec { get; set; }

        }
    }
    [MetadataType(typeof(SCHEDULE.SchedMetadata))]

    public partial class SCHEDULE

    {

        private sealed class SchedMetadata

        {

            [Display(Name = "Approval Status")]
            public string IsApproved { get; set; }

        }
    }
}

