using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Models
{
    public class DbInitialize
    {
        public static void Init(BicycleContext context)
        {
            if (!context.Bicycles.Any())
            {
                context.Bicycles.AddRange(
                    new Bicycle
                    {
                        Model = "b-14",
                        Year = 2018,
                        Company = "Blue Sea Import and Export Co., Ltd.",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/CITRSIM-Cannondale-U-SuperSixEVOCarbonDiscUltegraRoaadBike_Black.jpg",
                        Price = 200,
                        Country = "China",
                        Popularity = Popularity.two
                    },
                    new Bicycle
                    {
                        Model = "C11751MBLK",
                        Year = 2021,
                        Company = "Cannondale",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/CITRSIM-Cannondale-U-SuperSixEVOCarbonDisc105RoadBike_Black.jpg",
                        Price = 300,
                        Country = "Canada",
                        Popularity = Popularity.three
                    },
                    new Bicycle
                    {
                      Model = "C15501FBLU",
                      Year = 2020,
                      Company = "Cannondale",
                      ImageUrl = "https://www.hargrovescycles.co.uk/images/CITRSIM-Cannondale-W-TopstoneCaron4GravelBike_Purple.jpg",
                      Price = 200,
                      Country = "Canada",
                      Popularity = Popularity.four
                    },
                    new Bicycle
                    {
                        Model = "C15501MCHM",
                        Year = 2021,
                        Company = "GoldBike",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/CITRSIM-Cannondale-U-TopstoneCaron4GravelBike_Gold.jpg",
                        Price = 400,
                        Country = "Canada",
                        Popularity = Popularity.three
                    },
                    new Bicycle
                    {
                      Model = "C15601MGRA",
                      Year = 2010,
                      Company = "Cannondale",
                      ImageUrl = "https://www.hargrovescycles.co.uk/images/CITRSIM-Cannondale-U-TopstoneCaron5GravelBike_Grey.jpg",
                      Price = 400,
                      Country = "Canada",
                      Popularity = Popularity.one
                    },
                    new Bicycle
                    {
                        Model = "293291313649",
                        Year = 2021,
                        Company = "Specialized",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/spec/94421-31_roubaix-expert-carb-wht_hero.jpg",
                        Price = 400,
                        Country = "Germany",
                        Popularity = Popularity.three
                    },
                    new Bicycle
                    {
                        Model = "C15601MGRA",
                        Year = 2017,
                        Company = "Specialized",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/citrsim-specialized-m-roubaixsportroadbike_silver.jpg",
                        Price = 300,
                        Country = "Germany",
                        Popularity = Popularity.two
                    },
                    new Bicycle
                    {
                        Model = "292661303305",
                        Year = 2021,
                        Company = "Specialized",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/96220-50_DIVERGE-COMP-CARBON-ICEBLU-CLY-CSTUMBR_HERO.jpg",
                        Price = 400,
                        Country = "Germany",
                        Popularity = Popularity.five
                    },
                    new Bicycle
                    {
                        Model = "290924303306",
                        Year = 2019,
                        Company = "Specialized",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/spec/96220-52_diverge-comp-carbon-carb-smk-chrm_hero.jpg",
                        Price = 350,
                        Country = "Germany",
                        Popularity = Popularity.two
                    },
                    new Bicycle
                    {
                        Model = "293285313656",
                        Year = 2021,
                        Company = "Specialized",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/citrsim-specialized-m-roubaixsportroadbike_silver.jpg",
                        Price = 400,
                        Country = "Germany",
                        Popularity = Popularity.five
                    },
                    new Bicycle
                    {
                        Model = "YQBR5I",
                        Year = 2019,
                        Company = "Bianchi",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/2021-bianchi-sprint-105-disc.jpg",
                        Price = 350,
                        Country = "Italy",
                        Popularity = Popularity.two
                    },
                    new Bicycle
                    {
                        Model = "PRO DK GREY",
                        Year = 2021,
                        Company = "Axon Rides",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/Axon%20Rides%20Pro%20Dark%20Grey%20Hydraulic_002-2.jpg",
                        Price = 400,
                        Country = "France",
                        Popularity = Popularity.five
                    },
                    new Bicycle
                    {
                        Model = "YQBR5I",
                        Year = 2019,
                        Company = "Santa Cruz",
                        ImageUrl ="https://www.hargrovescycles.co.uk/images/5010.jpeg",
                        Price = 350,
                        Country = "Italy",
                        Popularity = Popularity.two
                    },
                    new Bicycle
                    {
                        Model = "58-21228-152",
                        Year = 2021,
                        Company = "Axon Rides",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/Axon%20Rides%20Pro%20Dark%20Grey%20Hydraulic_002-2.jpg",
                        Price = 200,
                        Country = "Spain",
                        Popularity = Popularity.one
                    },
                    new Bicycle
                    {
                        Model = "YQBR5I",
                        Year = 2021,
                        Company = "Specialized",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/spec/91520-44_rockhopper-elite-29-redwd-spr_hero.jpg",
                        Price = 350,
                        Country = "Germany",
                        Popularity = Popularity.three
                    },
                    new Bicycle
                    {
                        Model = "58-21228-152",
                        Year = 2021,
                        Company = "Specialized",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/spec/98120-50_creo-sl-comp-carbon-dovgry-gldgstprl-rktred_hero.jpg",
                        Price = 200,
                        Country = "Germany",
                        Popularity = Popularity.two
                    },
                    new Bicycle
                    {
                        Model = "401300",
                        Year = 2021,
                        Company = "Cube",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/Cube-Aim-Pro-blackblue.jpg.jpg",
                        Price = 350,
                        Country = "Germany",
                        Popularity = Popularity.four
                    },
                    new Bicycle
                    {
                        Model = "58-21228-152",
                        Year = 2022,
                        Company = "Specialized",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/citrsim-cannondale-m-quickneo2slremixte_blue.png",
                        Price = 200,
                        Country = "Germany",
                        Popularity = Popularity.five
                    },
                    new Bicycle
                    {
                        Model = "FG258F",
                        Year = 2021,
                        Company = "GoldenBike",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/cannondale-moterra-neo-5-2021.jpg",
                        Price = 350,
                        Country = "Spain",
                        Popularity = Popularity.one
                    },
                    new Bicycle
                    {
                        Model = "HY67cJ",
                        Year = 2021,
                        Company = "GoldenBike",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/citrsim-cannondale-m-quickneosl2_grey.png",
                        Price = 150,
                        Country = "Canada",
                        Popularity = Popularity.five
                    },
                    new Bicycle
                    {
                        Model = "JDD34",
                        Year = 2021,
                        Company = "Cube",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/spec/90020-60_allez-e5-sport-dovgry-blk_hero.jpg",
                        Price = 450,
                        Country = "Spain",
                        Popularity = Popularity.two
                    },
                    new Bicycle
                    {
                        Model = "KD673",
                        Year = 2021,
                        Company = "Cube",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/citrsim-cannondale-m-quickneosl2_grey.png",
                        Price = 300,
                        Country = "Canada",
                        Popularity = Popularity.five
                    },
                    new Bicycle
                    {
                        Model = "JKDwdvwh5w",
                        Year = 2011,
                        Company = "Super",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/specturbovado3grey.jpeg",
                        Price = 450,
                        Country = "Spain",
                        Popularity = Popularity.five
                    },
                    new Bicycle
                    {
                        Model = "JDWDH6483",
                        Year = 2019,
                        Company = "Super",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/95020-59_vado-40-nb-carb-blk-lqdsil_hero.jpg",
                        Price = 300,
                        Country = "Canada",
                        Popularity = Popularity.one
                    },
                     new Bicycle
                     {
                         Model = "MMDEJ3",
                         Year = 2015,
                         Company = "Canonadale",
                         ImageUrl = "https://www.hargrovescycles.co.uk/images/trail%208%20yellow.jpg",
                         Price = 450,
                         Country = "Germany",
                         Popularity = Popularity.two
                     },
                    new Bicycle
                    {
                        Model = "KDEJFE8e",
                        Year = 2020,
                        Company = "Birch",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/403100-Cube-Attention-grey-n-red-2021-0.jpg",
                        Price = 300,
                        Country = "France",
                        Popularity = Popularity.three
                    },
                     new Bicycle
                     {
                         Model = "MDLE&EF",
                         Year = 2016,
                         Company = "Cube",
                         ImageUrl = "https://www.hargrovescycles.co.uk/images/401410_light_zoom.jpg",
                         Price = 450,
                         Country = "France",
                         Popularity = Popularity.five
                     },
                    new Bicycle
                    {
                        Model = "KDEJFE8e",
                        Year = 2020,
                        Company = "Birch",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/aim%20sl.jpg",
                        Price = 300,
                        Country = "France",
                        Popularity = Popularity.one
                    },
                     new Bicycle
                     {
                         Model = "KDELFEF",
                         Year = 2018,
                         Company = "Nano",
                         ImageUrl = "https://www.hargrovescycles.co.uk/images/Cube-Nuroad-Pro-desertblack.jpg.jpg",
                         Price = 450,
                         Country = "Italy",
                         Popularity = Popularity.three
                     },
                    new Bicycle
                    {
                        Model = "BJDEOF58",
                        Year = 2017,
                        Company = "Nano",
                        ImageUrl = "https://www.hargrovescycles.co.uk/images/403160_light_zoom.jpg",
                        Price = 300,
                        Country = "Italy",
                        Popularity = Popularity.three
                    }

                );
            }

            context.SaveChanges();
        }
    }
}
