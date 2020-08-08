﻿// ***********************************************************************
// Assembly         : SSDMGMT.Data.Service
// Author           : rapril
// Created          : 06-30-2020
//
// Last Modified By : rapril
// Last Modified On :
// ***********************************************************************
// <copyright file="ParseBasicTemplate.cs" company="Supply Side Data Management LLC">
//     Copyright ©  2020 Supply Side Data Management. All rights reserved
// </copyright>
// <summary></summary>
// ***********************************************************************

using EXCell.ConfigurationStore;
using EXCell.DataStructure;
using Microsoft.Extensions.Configuration; 
using System;
using System.Collections.Generic;
using System.Linq;

namespace EXCell.Layouts
{
    public class Layout : ILayout
    {
        private readonly IConfiguration Configuration;

        public readonly IReadOnlyCollection<string> productTypes = new List<string> 
        { 
            "CA -- CASE",
            "DS -- Display",
            "EA -- Each",
            "MX -- Mod Pallet(Mixed)",
            "PK -- Package",
            "PL -- Pallet",
            "TL -- TRANSPORT_LOAD"
        };

        public readonly IReadOnlyCollection<string> dataCarrierTypeCodes = new List<string>
        {
            "EAN_13 -- EAN 13",
            "EAN_13_COMPOSITE -- EAN 13 COMPOSITE",
            "EAN_13_WITH_FIVE_DIGIT_ADD_ON -- EAN 13 WITH FIVE DIGIT ADD ON",
            "EAN_13_WITH_TWO_DIGIT_ADD_ON -- EAN 13 WITH TWO DIGIT ADD ON",
            "EAN_8 -- EAN 8",
            "EAN_8_COMPOSITE -- EAN 8 COMPOSITE",
            "GS1_128 -- GS1 128",
            "GS1_128_COMPOSITE -- GS1 128 COMPOSITE",
            "GS1_DATA_MATRIX -- GS1 DATA MATRIX",
            "GS1_DATABAR_EXPANDED -- GS1 DATABAR EXPANDED",
            "GS1_DATABAR_EXPANDED_COMPOSITE -- GS1 DATABAR EXPANDED COMPOSITE",
            "GS1_DATABAR_EXPANDED_STACKED -- GS1 DATABAR EXPANDED STACKED",
            "GS1_DATABAR_EXPANDED_STACKED_COMPOSITE -- GS1 DATABAR EXPANDED STACKED COMPOSITE",
            "GS1_DATABAR_LIMITED -- GS1 DATABAR LIMITED",
            "GS1_DATABAR_LIMITED_COMPOSITE -- GS1 DATABAR LIMITED COMPOSITE",
            "GS1_DATABAR_OMNIDIRECTIONAL -- GS1 DATABAR OMNIDIRECTIONAL",
            "GS1_DATABAR_OMNIDIRECTIONAL_COMPOSITE -- GS1 DATABAR OMNIDIRECTIONAL COMPOSITE",
            "GS1_DATABAR_STACKED -- GS1 DATABAR STACKED",
            "GS1_DATABAR_STACKED_COMPOSITE -- GS1 DATABAR STACKED COMPOSITE",
            "GS1_DATABAR_STACKED_OMNIDIRECTIONAL -- GS1 DATABAR STACKED OMNIDIRECTIONAL",
            "GS1_DATABAR_STACKED_OMNIDIRECTIONAL_COMPOSITE -- GS1 DATABAR STACKED OMNIDIRECTIONAL COMPOSITE",
            "GS1_DATABAR_TRUNCATED -- GS1 DATABAR TRUNCATED",
            "GS1_DATABAR_TRUNCATED_COMPOSITE -- GS1 DATABAR TRUNCATED COMPOSITE",
            "GS1_QR_CODE -- GS1 QR CODE",
            "ITF_14 -- ITF 14",
            "NO_BARCODE -- NO BARCODE",
            "UPC_A -- UPC A",
            "UPC_A_COMPOSITE -- UPC A COMPOSITE",
            "UPC_A_WITH_FIVE_DIGIT_ADD_ON -- UPC A WITH FIVE DIGIT ADD ON",
            "UPC_A_WITH_TWO_DIGIT_ADD_ON -- UPC A WITH TWO DIGIT ADD ON",
            "UPC_E -- UPC E",
            "UPC_E_COMPOSITE -- UPC E COMPOSITE",
            "UPC_E_FIVE_DIGIT_ADD_ON -- UPC E FIVE DIGIT ADD ON",
            "UPC_E_WITH_TWO_DIGIT_ADD_ON -- UPC E WITH TWO DIGIT ADD ON",
            "EPC_ENABLED_RFID_TAG -- EPC Enabled RFID Tag"
        };

        public readonly IReadOnlyCollection<string> countryCodes = new List<string>
        {
            "AF -- AFGHANISTAN",
            "AX -- ALAND ISLANDS",
            "AL -- ALBANIA",
            "DZ -- ALGERIA",
            "AS -- AMERICAN SAMOA",
            "AD -- ANDORRA",
            "AO -- ANGOLA",
            "AI -- ANGUILLA",
            "AQ -- ANTARCTICA",
            "AG -- ANTIGUA AND BARBUDA",
            "AR -- ARGENTINA",
            "AM -- ARMENIA",
            "AW -- ARUBA",
            "AU -- AUSTRALIA",
            "AT -- AUSTRIA",
            "AZ -- AZERBAIJAN",
            "BS -- BAHAMAS",
            "BH -- BAHRAIN",
            "BD -- BANGLADESH",
            "BB -- BARBADOS",
            "BY -- BELARUS",
            "BE -- BELGIUM",
            "BZ -- BELIZE",
            "BJ -- BENIN",
            "BM -- BERMUDA",
            "BT -- BHUTAN",
            "BO -- BOLIVIA",
            "BA -- BOSNIA AND HERZEGOWINA",
            "BW -- BOTSWANA",
            "BV -- BOUVET ISLAND",
            "BR -- BRAZIL",
            "IO -- BRITISH INDIAN OCEAN TERRITORY",
            "BN -- BRUNEI DARUSSALAM",
            "BG -- BULGARIA",
            "BF -- BURKINA FASO",
            "BI -- BURUNDI",
            "KH -- CAMBODIA",
            "CM -- CAMEROON",
            "CA -- CANADA",
            "CV -- CAPE VERDE",
            "KY -- CAYMAN ISLANDS",
            "CF -- CENTRAL AFRICAN REPUBLIC",
            "TD -- CHAD",
            "CL -- CHILE",
            "CN -- CHINA",
            "CX -- CHRISTMAS ISLAND",
            "CC -- COCOS (KEELING) ISLANDS",
            "CO -- COLOMBIA",
            "KM -- COMOROS",
            "CG -- CONGO",
            "CK -- COOK ISLANDS",
            "CR -- COSTA RICA",
            "CI -- COTE D'IVOIRE",
            "HR -- CROATIA",
            "CU -- CUBA",
            "CY -- CYPRUS",
            "CZ -- CZECH REPUBLIC",
            "DK -- DENMARK",
            "DJ -- DJIBOUTI",
            "DM -- DOMINICA",
            "DO -- DOMINICAN REPUBLIC",
            "EC -- ECUADOR",
            "EG -- EGYPT",
            "SV -- EL SALVADOR",
            "GQ -- EQUATORIAL GUINEA",
            "ER -- ERITREA",
            "EE -- ESTONIA",
            "ET -- ETHIOPIA",
            "EU -- EUROPEAN UNION",
            "NEU -- NON EUROPEAN ",
            "FK -- FALKLAND ISLANDS (MALVINAS)",
            "FO -- FAROE ISLANDS",
            "FJ -- FIJI",
            "FI -- FINLAND",
            "FR -- FRANCE",
            "FX -- FRANCE, METROPOLITAN",
            "GF -- FRENCH GUIANA",
            "PF -- FRENCH POLYNESIA",
            "TF -- FRENCH SOUTHERN TERRITORIES",
            "GA -- GABON",
            "GM -- GAMBIA",
            "GE -- GEORGIA",
            "DE -- GERMANY",
            "GH -- GHANA",
            "GI -- GIBRALTAR",
            "GR -- GREECE",
            "GL -- GREENLAND",
            "GD -- GRENADA",
            "GP -- GUADELOUPE",
            "GU -- GUAM",
            "GT -- GUATEMALA",
            "GN -- GUINEA",
            "GW -- GUINEA-BISSAU",
            "GY -- GUYANA",
            "HT -- HAITI",
            "HM -- HEARD AND MC DONALD ISLANDS",
            "HN -- HONDURAS",
            "HK -- HONG KONG",
            "HU -- HUNGARY",
            "IS -- ICELAND",
            "IN -- INDIA",
            "ID -- INDONESIA",
            "IR -- IRAN (ISLAMIC REPUBLIC OF)",
            "IQ -- IRAQ",
            "IE -- IRELAND",
            "IM -- ISLE OF MAN",
            "IL -- ISRAEL",
            "IT -- ITALY",
            "JM -- JAMAICA",
            "JP -- JAPAN",
            "JE -- JERSEY",
            "JO -- JORDAN",
            "KZ -- KAZAKHSTAN",
            "KE -- KENYA",
            "KI -- KIRIBATI",
            "KP -- KOREA DEMOCRATIC PEOPLES REPUBLIC OF [NORTH] KOREA)",
            "KR -- KOREA (REPUBLIC OF [SOUTH] KOREA)",
            "KW -- KUWAIT",
            "KG -- KYRGYZSTAN",
            "LA -- LAO PEOPLE'S DEMOCRATIC REPUBLIC",
            "LV -- LATVIA",
            "LB -- LEBANON",
            "LS -- LESOTHO",
            "LR -- LIBERIA",
            "LY -- LIBYAN ARAB JAMAHIRIYA",
            "LI -- LIECHTENSTEIN",
            "LT -- LITHUANIA",
            "LU -- LUXEMBOURG",
            "MO -- MACAU",
            "MK -- MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF",
            "MG -- MADAGASCAR",
            "MW -- MALAWI",
            "MY -- MALAYSIA",
            "MV -- MALDIVES",
            "ML -- MALI",
            "MT -- MALTA",
            "MH -- MARSHALL ISLANDS",
            "MQ -- MARTINIQUE",
            "MR -- MAURITANIA",
            "MU -- MAURITIUS",
            "YT -- MAYOTTE",
            "MX -- MEXICO",
            "FM -- MICRONESIA (FEDERATED STATES OF)",
            "MD -- MOLDOVA, REPUBLIC OF",
            "MC -- MONACO",
            "MN -- MONGOLIA",
            "MS -- MONTSERRAT",
            "MA -- MOROCCO",
            "MZ -- MOZAMBIQUE",
            "MM -- MYANMAR",
            "NA -- NAMIBIA",
            "NR -- NAURU",
            "NP -- NEPAL",
            "NL -- NETHERLANDS",
            "AN -- NETHERLANDS ANTILLES",
            "NC -- NEW CALEDONIA",
            "NZ -- NEW ZEALAND",
            "NI -- NICARAGUA",
            "NE -- NIGER",
            "NG -- NIGERIA",
            "NU -- NIUE",
            "NF -- NORFOLK ISLAND",
            "MP -- NORTHERN MARIANA ISLANDS",
            "NO -- NORWAY",
            "OM -- OMAN",
            "PK -- PAKISTAN",
            "PW -- PALAU",
            "PS -- PALESTINIAN TERRITORY, OCCUPIED",
            "PA -- PANAMA",
            "PG -- PAPUA NEW GUINEA",
            "PY -- PARAGUAY",
            "PE -- PERU",
            "PH -- PHILIPPINES",
            "PN -- PITCAIRN",
            "PL -- POLAND",
            "PT -- PORTUGAL",
            "PR -- PUERTO RICO",
            "QA -- QATAR",
            "RE -- REUNION",
            "RO -- ROMANIA",
            "RU -- RUSSIAN FEDERATION",
            "RW -- RWANDA",
            "KN -- SAINT KITTS AND NEVIS",
            "LC -- SAINT LUCIA",
            "VC -- SAINT VINCENT AND THE GRENADINES",
            "WS -- SAMOA",
            "SM -- SAN MARINO",
            "ST -- SAO TOME AND PRINCIPE",
            "SA -- SAUDI ARABIA",
            "SN -- SENEGAL",
            "CS -- SERBIA AND MONTENEGRO",
            "SC -- SEYCHELLES",
            "SL -- SIERRA LEONE",
            "SG -- SINGAPORE",
            "SK -- SLOVAKIA",
            "SI -- SLOVENIA",
            "SB -- SOLOMON ISLANDS",
            "SO -- SOMALIA",
            "ZA -- SOUTH AFRICA",
            "GS -- SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS",
            "ES -- SPAIN",
            "LK -- SRI LANKA",
            "SH -- ST. HELENA",
            "PM -- ST. PIERRE AND MIQUELON",
            "SD -- SUDAN",
            "SR -- SURINAME",
            "SJ -- SVALBARD AND JAN MAYEN ISLANDS",
            "SZ -- SWAZILAND",
            "SE -- SWEDEN",
            "CH -- SWITZERLAND",
            "SY -- SYRIAN ARAB REPUBLIC",
            "TW -- TAIWAN, PROVINCE OF CHINA",
            "TJ -- TAJIKISTAN",
            "TZ -- TANZANIA, UNITED REPUBLIC OF",
            "TH -- THAILAND",
            "CD -- THE DEMOCRATIC REPUBLIC OF THE CONGO",
            "TL -- TIMOR-LESTE",
            "TG -- TOGO",
            "TK -- TOKELAU",
            "TO -- TONGA",
            "TT -- TRINIDAD AND TOBAGO",
            "TN -- TUNISIA",
            "TR -- TURKEY",
            "TM -- TURKMENISTAN",
            "TC -- TURKS AND CAICOS ISLANDS",
            "TV -- TUVALU",
            "UG -- UGANDA",
            "UA -- UKRAINE",
            "AE -- UNITED ARAB EMIRATES",
            "GB -- UNITED KINGDOM",
            "US -- UNITED STATES",
            "UM -- UNITED STATES MINOR OUTLYING ISLANDS",
            "UY -- URUGUAY",
            "UZ -- UZBEKISTAN",
            "VU -- VANUATU",
            "VA -- VATICAN CITY STATE (HOLY SEE)",
            "VE -- VENEZUELA",
            "VN -- VIET NAM",
            "VG -- VIRGIN ISLANDS (BRITISH)",
            "VI -- VIRGIN ISLANDS (U.S.)",
            "WF -- WALLIS AND FUTUNA ISLANDS",
            "EH -- WESTERN SAHARA",
            "YE -- YEMEN",
            "ZM -- ZAMBIA",
            "ZW -- ZIMBABWE",
            "BL -- SAINT-BARTHELEMY",
            "GG -- GUERNSEY",
            "ME -- MONTENEGRO",
            "MF -- SAINT-MARTIN (FRENCH PART)",
            "RS -- SERBIA",
            "SS -- SOUTH SUDAN"
        };

        public readonly IReadOnlyCollection<string> typeOfInformations = new List<string>
        {
            "AUDIO -- Audio",
            "CERTIFICATION -- Certification",
            "CHEMICAL_ASSESSMENT_SUMMARY -- Chemical Assessment Summary",
            "CHEMICAL_SAFETY_REPORT -- Chemical Safety Report",
            "CONSUMER_HANDLING_AND_STORAGE -- Consumer Handling & Storage",
            "DIET_CERTIFICATE -- Diet Certificate",
            "DOCUMENT -- Document",
            "GROUP_CHARACTERISTIC_SHEET -- Group Characteristic Sheet",
            "HAZARDOUS_SUBSTANCES_DATA -- Hazardous Substances Data",
            "IFU -- IFU",
            "LOGO -- Logo",
            "MARKETING_INFORMATION -- Marketing Information",
            "MOBILE_DEVICE_IMAGE -- Mobile Device Image",
            "OTHER_EXTERNAL_INFORMATION -- Other External Information",
            "OUT_OF_PACKAGE_IMAGE -- Out of Package Image",
            "PLANOGRAM -- Planogram",
            "PRODUCT_IMAGE -- Product Image",
            "PRODUCT_WEBSITE -- Product Website",
            "PRODUCT_LABEL_IMAGE -- Product Label Image",
            "QUALITY_CONTROL_PLAN -- Quality Control Plan",
            "RECIPE_WEBSITE -- Recipe Website",
            "REGULATORY_INSPECTION_AUDIT -- Regulatory Inspection Audit",
            "RISK_ANALYSIS_DOCUMENT -- Risk Analysis Document",
            "SAFETY_DATA_SHEET -- Safety Data Sheet",
            "SAMPLE_SHIPPING_ORDER -- Sample Shipping Order",
            "TESTING_METHODOLOGY_RESULTS -- Testing Methodology Results",
            "TRADE_ITEM_DESCRIPTION -- Trade Item Description",
            "VIDEO -- Video",
            "WARRANTY_INFORMATION -- Warranty Information",
            "WEBSITE -- Website",
            "CHILD_NUTRITION_LABEL -- Child Nutrition Label",
            "PRODUCT_FORMULATION_STATEMENT -- Product Formulation Statement",
            "SAFETY_SUMMARY_SHEET -- Safety Summary Sheet",
            "CROSSSECTION_VIEW -- CrossSection View",
            "DOP_SHEET -- DOP Sheet",
            "ENERGY_LABEL -- Energy Label",
            "INTERNAL_VIEW -- Internal View",
            "TRADE_ITEM_IMAGE_WITH_DIMENSIONS -- Trade Item Image with Dimensions",
            "ZOOM_VIEW -- Zoom View",
            "360_DEGREE_IMAGE -- 360 Degree Image",
            "ASSEMBLY_INSTRUCTIONS -- Assembly Instructions",
            "PACKAGING_ARTWORK -- Packaging Artwork",
            "DRUG_FACT_LABEL -- Material Samples",
            "SUMMARY_OF_PRODUCT_CHARACTERISTICS -- Summary of Product Characteristics",
            "MATERIAL_SAMPLES -- Material Samples",
            "NUTRITION_FACT_LABEL -- Nutrition Fact Label",
            "MOBILE_READY_HERO_IMAGE -- Mobile Ready Hero Image",
            "ORGANIC_CERTIFICATE -- Organic Certificate",
            "QR_CODE -- Link to QR Code",
            "INGREDIENTS_LABEL -- Ingredients label",
            "MONTAGE_IMAGE -- Montage Image",
            "DISPOSAL_INSTRUCTIONS -- Instructions for disposal"
        };

        public readonly IReadOnlyCollection<string> identificationKeyCodes = new List<string>
        {
            "GTIN_8 -- GTIN_8",
            "GTIN_12 -- GTIN_12",
            "GTIN_13 -- GTIN_13",
            "GTIN_14 -- GTIN_14"
        };

        public readonly IReadOnlyCollection<string> MassUOM = new List<string>
        {
            "KGM -- Kilogram",
            "A43 -- Deadweight Tonnage",
            "GFI -- Gram of Fissile Isotope",
            "KUR -- Kilogram of Uranium",
            "X_DWT -- Penny Weight",
            "GRM -- Gram",
            "HGM -- Hectogram",
            "23 -- Grams Per Cubic Centimetre",
            "LTN -- Ton (UK) or long ton (US)",
            "STN -- Ton (US) or short ton (UK)",
            "TNE -- Tonne",
            "58 -- Net kilogram",
            "CGM -- Centigram",
            "APZ -- Troy ounce or apothecary ounce",
            "C18 -- Millimole",
            "C34 -- Mole",
            "CWA -- Hundred pound (cwt) / hundred weight (US)",
            "CWI -- Hundred weight(UK)",
            "D43 -- Atomic Mass Units (AMU)",
            "DG -- Decigram",
            "FH -- Micromole",
            "GRN -- Grain",
            "E4 -- Gross kilogram",
            "LBR -- Pound",
            "MC -- Microgram",
            "MGM -- Milligram",
            "X_NGM -- Nanogram",
            "ONZ -- Ounce",
            "NIU -- Number of International Unit",
            "CTM -- Metric Carat",
            "KDW -- Kilogram drained net weight",
            "KHY -- Kilogram of hydrogen peroxide",
            "KMA -- Kilogram of methylamine",
            "KNI -- Kilogram of nitrogen",
            "KPH -- Kilogram of potassium hydroxide (caustic potash)",
            "KPO -- Kilogram of potassium oxide",
            "KPP -- Kilogram of phosphorus pentoxide (phosphoric anhydride)",
            "KSD -- Kilogram of substance 90% dry",
            "KSH -- Kilogram of sodium hydroxide (caustic soda)",
            "GL -- Gram Per Litre"
        };

        public readonly IReadOnlyCollection<string> AreaCountDimensionInfostorageMassVolumeUOM = new List<string>
        {
            "DMK -- Square decimetre",
            "A11 -- Angstrom",
            "A43 -- Deadweight Tonnage",
            "D40 -- Thousand Litre",
            "G26 -- Stere",
            "GFI -- Gram of Fissile Isotope",
            "KUR -- Kilogram of Uranium",
            "LD -- Litre / Day",
            "X_DWT -- Penny Weight",
            "X_HIN -- Hundredths of an Inch",
            "X_MPG -- Miles Per Gallon",
            "X_SIN -- Thirty Seconds of an Inch",
            "X_UIN -- Ten Thousandths of an Inch",
            "MMK -- Square millimetre",
            "BB -- Base box",
            "INK -- Square inch",
            "MIK -- Square mile",
            "FTK -- Square foot",
            "MTK -- Square metre",
            "YDK -- Square Yard",
            "EA -- Each",
            "1N -- Count",
            "2Q -- Kilo Becquerel",
            "5B -- Batch",
            "AS -- Assortment",
            "AXU -- Anti XA Unit",
            "BQL -- Becquerel",
            "CG -- Card",
            "XRO -- Roll",
            "X_CHD -- Centisimal Hahnemannian Dilution (CH)",
            "D63 -- Book",
            "DD -- Degree (Unit of Angel)",
            "DZN -- Dozen",
            "E27 -- Dose",
            "E37 -- Pixel",
            "E39 -- Dots per inch",
            "ELU -- ELISA Units",
            "GBQ -- Gigabecquerel",
            "GRO -- Gross",
            "HC -- Hundred count",
            "HD -- Half dozen",
            "HEP -- Histamine Equivalent Prick",
            "KIU -- Kallikrein inactivator unit.",
            "KT -- Kit",
            "X_KVN -- Korsakovian (K)",
            "LK -- Link",
            "LR -- Layer",
            "MIU -- Million International Unit (NIE)",
            "X_MLM -- Millesimai (LM)",
            "X_MTC -- Mother tincture (Dry material)",
            "NIU -- Number of International Units",
            "H87 -- Piece",
            "PD -- Pad",
            "PFU -- Plaque Forming unit(s)",
            "PNT -- Point",
            "X_PPC -- Pixel per centimetre",
            "X_PPI -- Pixel per inch",
            "PR -- Pair",
            "QB -- Page - hardcopy",
            "X_SPS -- Sample per second",
            "SQE -- SQ-E",
            "SET -- Set",
            "SX -- Shipment",
            "U2 -- Tablet",
            "E55 -- Use",
            "4H -- Micrometre",
            "CMT -- Centimetre",
            "KMT -- Kilometre",
            "DMT -- Decimetre",
            "FOT -- Foot",
            "H79 -- French gauge",
            "INH -- Inches",
            "LF -- Linear foot",
            "LM -- Linear metre",
            "MMT -- Millimetre",
            "MTR -- Metre",
            "SMI -- Mile (statute mile)",
            "YRD -- Yard",
            "A71 -- Femtometre",
            "2P -- Kilobyte",
            "4L -- Megabyte",
            "AD -- Byte",
            "E34 -- Gigabyte",
            "E35 -- Terabyte",
            "4G -- Microlitre",
            "BFT -- Board Foot",
            "BP -- Hundred board foot",
            "BLL -- Barrel US",
            "BUA -- Bushel (US)",
            "BUI -- Bushel (UK)",
            "CLT -- Centilitre",
            "DMQ -- Cubic decimetre",
            "CMQ -- Cubic centimetre",
            "FTQ -- Cubic foot",
            "INQ -- Cubic inch",
            "MTQ -- Cubic metre",
            "G21 -- Cup US",
            "DLT -- Decilitre",
            "DRA -- Dram (US)",
            "DRI -- Dram (UK)",
            "OZA -- Fluid ounce (US)",
            "OZI -- Fluid ounce (UK)",
            "G24 -- Tablespoon",
            "G25 -- Teaspoon",
            "GLI -- Gallon (UK)",
            "GLL -- Gallon (US)",
            "HLT -- Hectolitre",
            "K6 -- Kilolitre",
            "LTR -- Litre",
            "MLT -- Millilitre",
            "MMQ -- Cubic millimetre",
            "PTD -- Dry Pint (US)",
            "PTI -- Pint (UK)",
            "PTL -- Liquid pint (US)",
            "G23 -- Peck",
            "QTD -- Quart (US dry)",
            "QTL -- Liquid quart (US)",
            "23 -- Grams Per Cubic Centimetre",
            "LTN -- Ton (UK) or long ton (US)",
            "STN -- Ton (US) or short ton (UK)",
            "TNE -- Tonne",
            "58 -- Net kilogram",
            "CGM -- Centigram",
            "APZ -- Troy ounce or apothecary ounce",
            "C18 -- Millimole",
            "C34 -- Mole",
            "CWA -- Hundred pound (cwt) / hundred weight (US)",
            "CWI -- Hundred weight(UK)",
            "D43 -- Atomic Mass Units (AMU)",
            "DG -- Decigram",
            "FH -- Micromole",
            "GRM -- Gram",
            "GRN -- Grain",
            "E4 -- Gross kilogram",
            "HGM -- Hectogram",
            "KGM -- Kilogram",
            "LBR -- Pound",
            "MC -- Microgram",
            "MGM -- Milligram",
            "X_NGM -- Nanogram",
            "ONZ -- Ounce",
            "XRE -- Retinol Equivalent (RE)",
            "GL -- Gram Per Litre",
            "BAR -- Bar (Unit of Pressure)",
            "P1  -- Percent",
            "12 -- Packet",
            "AM -- Ampoule",
            "AP -- Assorted Pack/Setpack",
            "JC -- Caplet",
            "AV -- Capsule",
            "DC -- Disk (Disc)",
            "JX -- Exposure",
            "GN -- Gross Gallons",
            "IH -- Inhaler",
            "JV -- Ovules",
            "JN -- Pan",
            "DAY -- Days",
            "JL -- Refill",
            "AR -- Suppository",
            "SZ -- Syringe",
            "JT -- Tin",
            "Y4 -- Tub",
            "TB -- Tube",
            "VI -- Vial",
            "F27 -- Gram Per Hour",
            "BPM -- Beats Per Minute ",
            "CFU  -- Colony Forming Units",
            "Q32 -- Femtolitre ",
            "AWG -- Gauge ",
            "MEQ -- Milliequivalents ",
            "MPN -- Most Probable Number",
            "Q34 -- Nanolitre ",
            "C45 -- Nanometre ",
            "OPM -- Oscillations Per Minute ",
            "Q33 -- Picolitre ",
            "C52 -- Picometre ",
            "PTN -- Portion ",
            "PRS --  Potential Renal Solute Load ",
            "FJ -- Sizing Factor",
            "TPI -- Teeth Per Inch ",
            "KO -- The milliequivalence caustic potash per gram of product",
            "NU -- Newton Metre",
            "CTM -- Metric Carat",
            "KDW -- Kilogram drained net weight",
            "KHY -- Kilogram of hydrogen peroxide",
            "KMA -- Kilogram of methylamine",
            "KNI -- Kilogram of nitrogen",
            "KPH -- Kilogram of potassium hydroxide (caustic potash)",
            "KPO -- Kilogram of potassium oxide",
            "KPP -- Kilogram of phosphorus pentoxide (phosphoric anhydride)",
            "KSD -- Kilogram of substance 90% dry",
            "KSH -- Kilogram of sodium hydroxide (caustic soda)",
            "LPA -- Litre of pure alcohol",
            "R9 -- Thousand cubic metre",
            "NCL -- Number of cells",
            "NPR -- Number of pairs",
            "XST -- Sheet",
            "T3 -- Thousand piece",
            "MTS -- Metre Per Second",
            "X_CFG -- Colony Forming Units per gram (CFU/g)",
            "X_CFP -- Colony Forming Units per Pound (CFU/lb)",
            "X_IUK -- International Units per Kilogram (IU/kg)",
            "X_RAE -- Retinol Activity Equivalents",
            "E36 -- Petabyte"
        };

        public readonly IReadOnlyCollection<string> DimensionsUOM = new List<string>
        {
            "4H -- Micrometre",
            "A11 -- Angstrom",
            "X_HIN -- Hundredths of an Inch",
            "X_SIN -- Thirty Seconds of an Inch",
            "X_UIN -- Ten Thousandths of an Inch",
            "CMT -- Centimetre",
            "KMT -- Kilometre",
            "DMT -- Decimetre",
            "FOT -- Foot",
            "H79 -- French gauge",
            "INH -- Inches",
            "LF -- Linear foot",
            "LM -- Linear metre",
            "MMT -- Millimetre",
            "MTR -- Metre",
            "SMI -- Mile (statute mile)",
            "YRD -- Yard",
            "AWG -- Gauge",
            "C45 -- Nanometre",
            "C52 -- Picometre",
            "CFU -- Colony Forming Units",
            "A71 -- Femtometre"
        };

        public readonly IReadOnlyCollection<string> VolumeUOM = new List<string>
        {
            "DMQ -- Cubic decimetre",
            "CMQ -- Cubic centimetre",
            "D40 -- Thousand Litre",
            "LD -- Litre / Day",
            "MTQ -- Cubic metre",
            "4G -- Microlitre",
            "BFT -- Board Foot",
            "BP -- Hundred board foot",
            "BLL -- Barrel US",
            "BUA -- Bushel (US)",
            "BUI -- Bushel (UK)",
            "CLT -- Centilitre",
            "FTQ -- Cubic foot",
            "INQ -- Cubic inch",
            "G21 -- Cup US",
            "DLT -- Decilitre",
            "DRA -- Dram (US)",
            "DRI -- Dram (UK)",
            "OZA -- Fluid ounce (US)",
            "OZI -- Fluid ounce (UK)",
            "G24 -- Tablespoon",
            "G25 -- Teaspoon",
            "GLI -- Gallon (UK)",
            "GLL -- Gallon (US)",
            "HLT -- Hectolitre",
            "K6 -- Kilolitre",
            "LTR -- Litre",
            "MLT -- Millilitre",
            "MMQ -- Cubic millimetre",
            "PTD -- Dry Pint (US)",
            "PTI -- Pint (UK)",
            "PTL -- Liquid pint (US)",
            "G23 -- Peck",
            "Q32 -- Femtolitre",
            "Q33 -- Picolitre",
            "Q34 -- Nanolitre",
            "LPA -- Litre of pure alcohol",
            "R9 -- Thousand cubic metre",
            "QTD -- Quart (US dry)",
            "QTL -- Liquid quart (US)",
            "NIU -- Number of International Unit"
        };

        public readonly IReadOnlyCollection<string> TemperatureUOM = new List<string>
        {
            "CEL -- Degree Celsius",
            "FAH -- Degree Fahrenheit",
            "KEL -- Kelvin"
        };

        public readonly IReadOnlyCollection<string> booleanVV = new List<string> { "true -- TRUE", "false -- FALSE" };

        public IEnumerable<IParam> LayoutParams(IRowLayoutManager manager)
        {
            var configOptions = new ConfigOptions();
            Configuration.GetSection(ConfigOptions.Config).Bind(configOptions);
            return new ParamBuilder(manager)
                .AddParam("RecordType", new List<string> { "ITEM -- ITEM", "MORE -- MORE" })
                .AddParam("Operation", new List<string> { "ADD -- ADD", "APPEND -- APPEND", "MODIFY -- MODIFY" })
                .AddParam("ImportItem", new List<string> { "Y -- YES", "N -- NO" })
                .AddParam("InformationProviderGLN", configOptions.informationProviderGLN)
                .AddParam("InformationProviderName", configOptions.informationProviderName)
                .AddParam("TypeOfItem", new List<string> { "GDSN", "NON-GDSN" })
                .AddParam("Gtin", string.Empty, 14, 14)
                .AddParam("GtinName", string.Empty, 50, 0)
                .AddParam("GtinNameLANG", "en -- English")
                .AddParam("ProductType", productTypes)
                .AddParam("BrandName", string.Empty, 50, 0)
                .AddParam("BrandOwnerGLN", string.Empty, 13, 13)
                .AddParam("BrandOwnerName", "en -- English")
                .AddParam("AlternateItemIdentification_groupController", "GroupBreak")
                .AddParam("AlternateItemIdentification_agency", "90")
                .AddParam("AlternateItemIdentification_id", string.Empty, 50, 0)
                .AddParam("CountryOfOrigin_groupController", "GroupBreak")
                .AddParam("CountryOfOrigin_countryCode", countryCodes)
                .AddParam("DataCarrier_groupController", "GroupBreak")
                .AddParam("DataCarrier_dataCarrierTypeCode", dataCarrierTypeCodes)
                .AddParam("ExternalFileLink_groupController", "GroupBreak")
                .AddParam("ExternalFileLink_externalFileLinkFileName", string.Empty, 100, 0)
                .AddParam("ExternalFileLink_fileFormatName", string.Empty, 5, 0)
                .AddParam("ExternalFileLink_typeOfInformation", typeOfInformations)
                .AddParam("ExternalFileLink_uniformResourceIdentifier", string.Empty, 255, 0)
                .AddParam("GlobalClassificationCategory_code", string.Empty, 10, 0)
                .AddParam("Gs1TradeItemIdentificationKey_groupController", "GroupBreak")
                .AddParam("Gs1TradeItemIdentificationKey_code", identificationKeyCodes)
                .AddParam("Gs1TradeItemIdentificationKey_value", string.Empty, 14, 8)
                .AddParam("Manufacturer_groupController", "GroupBreak")
                .AddParam("Manufacturer_gln", configOptions.manufacturerGLN)
                .AddParam("Manufacturer_name", configOptions.manufacturerName)
                .AddParam("MarketingMessage_groupController", "GroupBreak")
                .AddParam("MarketingMessage_tradeItemMarketingMessage", string.Empty, 255, 0)
                .AddParam("MarketingMessage_tradeItemMarketingMessageLANG", "en -- English")
                .AddParam("Depth", string.Empty, 5, 0)
                .AddParam("DepthUOM", DimensionsUOM)
                .AddParam("EffectiveDate", DateTime.Now)
                .AddParam("FunctionalName", string.Empty, 35, 0)
                .AddParam("FunctionalNameLANG", "en -- English")
                .AddParam("GrossWeight", string.Empty, 10, 0)
                .AddParam("GrossWeightUOM", MassUOM)
                .AddParam("Height", string.Empty, 10, 0)
                .AddParam("HeightUOM", DimensionsUOM)
                .AddParam("InnerPack", string.Empty, 10, 0)
                .AddParam("IsBaseUnit", booleanVV)
                .AddParam("IsConsumerUnit", booleanVV)
                .AddParam("IsDispatchUnit", booleanVV)
                .AddParam("IsDispatchUnitRDD", "ALL")
                .AddParam("IsInvoiceUnit", booleanVV)
                .AddParam("IsInvoiceUnitRDD", "ALL")
                .AddParam("IsOrderableUnit", booleanVV)
                .AddParam("IsOrderableUnitRDD", "ALL")
                .AddParam("IsVariableWeightItem", "false -- FALSE")
                .AddParam("MinimumTradeItemLifespanFromArrival", string.Empty, 4, 0)
                .AddParam("MinimumTradeItemLifespanFromArrivalRDD", "ALL")
                .AddParam("MinimumTradeItemLifespanFromProduction", string.Empty, 4, 0)
                .AddParam("MinimumTradeItemLifespanFromProductionRDD", "ALL")
                .AddParam("NetContent", string.Empty, 10, 0)
                .AddParam("NetContentUOM", AreaCountDimensionInfostorageMassVolumeUOM)
                .AddParam("NetWeight", string.Empty, 10, 0)
                .AddParam("NetWeightUOM", MassUOM)
                .AddParam("NonGTINPalletHi", string.Empty, 10, 0)
                .AddParam("NonGTINPalletHiRDD", "ALL")
                .AddParam("NonGTINPalletTi", string.Empty, 10, 0)
                .AddParam("NonGTINPalletTiRDD", "ALL")
                .AddParam("NumberOfItemsPerPallet", string.Empty, 10, 0)
                .AddParam("NumberOfItemsPerPalletRDD", "ALL")
                .AddParam("PackagingMarkedReturnable", booleanVV)
                .AddParam("ProductDescription", string.Empty, 200, 0)
                .AddParam("ProductDescriptionLANG", "en -- English")
                .AddParam("QuantityOfNextLevelWithinInnerPack", string.Empty, 10, 0)
                .AddParam("ShortDescription", string.Empty, 10, 0)
                .AddParam("ShortDescriptionLANG", "en -- English")
                .AddParam("StartAvailabilityDate", DateTime.Now)
                .AddParam("StartAvailabilityDateRDD", "ALL")
                .AddParam("TotalQuantityOfNextLowerTradeItem", string.Empty, 10, 0)
                .AddParam("Volume", string.Empty, 10, 0)
                .AddParam("VolumeUOM", VolumeUOM)
                .AddParam("Width", string.Empty, 10, 0)
                .AddParam("WidthUOM", DimensionsUOM)
                .AddParam("TradeItemTemperatureInformation_groupController", "GroupBreak")
                .AddParam("TradeItemTemperatureInformation_temperatureQualifierCode", "STORAGE_HANDLING -- Trade Item is being stored or handled.")
                .AddParam("TradeItemTemperatureInformation_maximumTemperature", string.Empty, 4, 0)
                .AddParam("TradeItemTemperatureInformation_maximumTemperatureUOM", "FAH -- Degree Fahrenheit")
                .AddParam("TradeItemTemperatureInformation_minimumTemperature", string.Empty, 4, 0)
                .AddParam("TradeItemTemperatureInformation_minimumTemperatureUOM", "FAH -- Degree Fahrenheit").Params;
        }

        public Layout(IConfiguration configuration)
        {
        }
    }
}