using System.Collections.Generic;
using GodEdictGen.Data;
using GodEdictGen.Helpers;
namespace GodEdictGen
{
    public class Edicts
    {
        private static readonly StaticEdictGenerator[] edicts = new StaticEdictGenerator[]
        {
           new StaticEdictGenerator
            (
               name:"God_Mode",
               modifiers: new ModifierGenerator[]
               {
                    new ModifierGenerator("science_ship_survey_speed", 5),
                    new ModifierGenerator("ship_anomaly_generation_chance_mult",2),
                    new ModifierGenerator("planet_building_cost_mult",5),
                    new ModifierGenerator("planet_building_build_speed_mult",5),
                    new ModifierGenerator("pop_happiness",5),
                    new ModifierGenerator("country_ship_upgrade_cost_mult",-.99),
                    new ModifierGenerator("leader_skill_levels",5),
                    new ModifierGenerator("species_leader_exp_gain",  5),
                    new ModifierGenerator("leader_age", 90000),
                    new ModifierGenerator("country_base_influence_produces_add", 50),
                    new ModifierGenerator("country_naval_cap_mult",10),
                    new ModifierGenerator("planet_pops_consumer_goods_upkeep_mult",-0.95)
               }.AddSet
               (
                   modifierFormat: "country_{0}_produces_mult",
                   modifierValue:5,
                   modifierNames:ModifierNamesData.GeneralResources
                ).AddSet
                (
                   modifierFormat:"country_{0}_tech_research_speed",
                   modifierValue:5,
                   modifierNames: ModifierNamesData.ScienceResources
                ).AddSet
                (
                   modifierFormat:"ship_{0}_mult",
                   modifierValue:.35,
                   modifierNames: new string[]
                   {
                       "fire_rate",
                       "speed",
                       "evasion"
                   }
                )
            ),
           new StaticEdictGenerator
            (
               name:"Leader_Age",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("leader_age",10000)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Research_Speedup",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("all_technology_research_speed",20)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Research_Income",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("station_researchers_produces_mult", 10),
               }.AddSet
                (
                   modifierFormat:"planet_researchers_{0}_produces_mult",
                   modifierValue: 2,
                   modifierNames: ModifierNamesData.ScienceResources
                )
            ),
           new StaticEdictGenerator
            (
               name:"Research_Alts_Add_5",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("num_tech_alternatives_add",5)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Research_Alts_Add_5_More",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("num_tech_alternatives_add",5)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Resource_Incomeboost",
               modifiers: ModifierGenerator.GenerateSet
                (
                    modifierFormat:"country_{0}_produces_mult",
                    modifierValue: 40,
                    modifierNames:ModifierNamesData.GeneralResources
                )
            ),
           new StaticEdictGenerator
            (
               name:"Resource_Storage_Add_1M",
               modifiers: ModifierGenerator.GenerateSet
               (
                   modifierFormat:"country_resource_max_{0}_add",
                   modifierValue: 1_000_000,
                   modifierNames:ModifierNamesData.ConstructionResources
               )
            ),
           new StaticEdictGenerator
            (
               name:"Pop_happiness_boost",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("pop_happiness",40)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Navy_boost",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("country_ship_upgrade_cost_mult", -5),
                   new ModifierGenerator("country_naval_cap_mult",20),
                   new ModifierGenerator("country_command_limit_add",400)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Influence_Boost",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("country_base_influence_produces_add", 1000)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Ship_Boost",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("ship_fire_rate_mult",.5),
                   new ModifierGenerator("ship_evasion_mult",.25),
                   new ModifierGenerator("ship_speed_mult",.25)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Leader_Boost",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("leader_skill_levels",5),
                   new ModifierGenerator("species_leader_exp_gain",5)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Planet_Boost",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("planet_building_build_speed_mult",10),
                   new ModifierGenerator("building_time_mult",-0.9)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Unity_Boost",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("country_unity_produces_mult",40)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Pop_growth_boost",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("pop_growth_speed", 100),
                   //new ModifierGenerator("pop_robot_build_speed_mult",100),
                   new ModifierGenerator("planet_pop_assembly_add", 100)

               }
            ),
           new StaticEdictGenerator
            (
               name:"megastructure_booster",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("megastructure_build_speed_mult", 100),
                   //new ModifierGenerator("mod_megastructure_build_cost_mult", -1.0)
               }
            ),
           //new StaticEdictGenerator
           // (
           //    name:"planet_fortification_booster",
           //    modifiers: new ModifierGenerator[]
           //    {
           //        //new ModifierGenerator("planet_fortification_strength", 20)
           //    }
           // ),
           new StaticEdictGenerator
            (
               name:"more_leaders",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("country_leader_cap", 100),
                   new ModifierGenerator("country_leader_pool_size", 200)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Trade_Attactive",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("country_trade_attractiveness", 20)
               }
            ),
           //new StaticEdictGenerator
           // (
           //    name:"Core_System",
           //    modifiers: new ModifierGenerator[]
           //    {
           //        //new ModifierGenerator("country_core_sector_system_cap",20)
           //    }
           // ),
           new StaticEdictGenerator
            (
               name:"Cheep_Fast_Orbital",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("country_ship_upgrade_cost_mult", -.99),
                   new ModifierGenerator("starbase_shipyard_capacity_add",10),
                   new ModifierGenerator("starbase_shipyard_build_cost_mult", -0.99),
                   new ModifierGenerator("starbase_shipyard_build_time_mult", -.99),
                   new ModifierGenerator("starbase_shipyard_build_speed_mult", 1000),
                   new ModifierGenerator("starbase_upgrade_cost_mult", -.99),
                   new ModifierGenerator("starbase_upgrade_time_mult",0),
                   new ModifierGenerator("starbase_upgrade_speed_mult", 1000)
               }
            ),
            new StaticEdictGenerator
            (
               name:"Rare_Resouce_Boost_30x_Multiplier",
               modifiers: ModifierGenerator.GenerateSet
                (
                   modifierFormat:"country_{0}_produces_mult",
                   modifierValue: 30,
                   modifierNames: ModifierNamesData.RareResouces
                )
            ),
            new StaticEdictGenerator
            (
               name:"Rare_Resouce_Boost_1000_Add",
               modifiers: ModifierGenerator.GenerateSet
                (
                   modifierFormat:"country_base_{0}_produces_add",
                   modifierValue: 1000,
                   modifierNames: ModifierNamesData.RareResouces
                )
            ),
           new StaticEdictGenerator
            (
               name:"Administrative_Overload_100x_Multiplier",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("country_admin_cap_mult",100)
               }
            ),
           new StaticEdictGenerator
            (
               name:"Administrative_Overload_1000_Add",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("country_admin_cap_add",1000)
               }
            ) ,
            new StaticEdictGenerator
            (
               name:"Colonial_DevelopmentSpeed_Overload_20x",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("planet_colony_development_speed_mult", 20)
               }
            ) ,
            new StaticEdictGenerator
            (
               name:"Terraforming_Overdrive",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("terraform_speed_mult", 10),
                   new ModifierGenerator("terraforming_cost_mult", -0.90)
               }
            ),
            new StaticEdictGenerator
            (
               name:"Shipyard_Overdrive",
               modifiers: new ModifierGenerator[]
               {
                   new ModifierGenerator("country_ship_upgrade_cost_mult",-.99),
               }
            ),
            new StaticEdictGenerator
            (
               name:"Shipbuild_Speed_Override",
               modifiers: ModifierGenerator.GenerateSet
                (
                   modifierFormat: "ship_{0}_cost_mult",
                   modifierValue: -.99,
                   modifierNames: ModifierNamesData.ShipClasses
                ).AddSet
                (
                   modifierFormat: "shipsize_{0}_build_speed_mult",
                   modifierValue: 10,
                   modifierNames: ModifierNamesData.ShipClasses
                )
            ),
            new StaticEdictGenerator
            (
               name:"Station_Build_Speed_Override",
               modifiers: ModifierGenerator.GenerateSet
                (
                   modifierFormat: "shipclass_{0}_build_speed_mult",
                   modifierValue: 10,
                   modifierNames: ModifierNamesData.StationClasses
                ).AddSet
                (
                   modifierFormat: "shipclass_{0}_build_build_cost",
                   modifierValue: 10,
                   modifierNames: ModifierNamesData.StationClasses
                )
            )

       };

        /*
            ,
            new StaticEdictGenerator
            (
               name:"",
               modifiers: new ModifierGenerator[]
               {
               }
            )
         *
         *
         */

        public StaticEdictGenerator this[int index]
        {
            get => edicts[index];
        }

        public int Length => edicts.Length;

        public IEnumerable<StaticEdictGenerator> All => edicts;
    }
}