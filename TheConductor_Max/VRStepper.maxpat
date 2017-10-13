{
	"patcher" : 	{
		"fileversion" : 1,
		"appversion" : 		{
			"major" : 7,
			"minor" : 3,
			"revision" : 4,
			"architecture" : "x64",
			"modernui" : 1
		}
,
		"rect" : [ 2257.0, 17.0, 1278.0, 848.0 ],
		"bglocked" : 0,
		"openinpresentation" : 0,
		"default_fontsize" : 12.0,
		"default_fontface" : 0,
		"default_fontname" : "Arial",
		"gridonopen" : 1,
		"gridsize" : [ 15.0, 15.0 ],
		"gridsnaponopen" : 1,
		"objectsnaponopen" : 1,
		"statusbarvisible" : 2,
		"toolbarvisible" : 1,
		"lefttoolbarpinned" : 0,
		"toptoolbarpinned" : 0,
		"righttoolbarpinned" : 0,
		"bottomtoolbarpinned" : 0,
		"toolbars_unpinned_last_save" : 0,
		"tallnewobj" : 0,
		"boxanimatetime" : 200,
		"enablehscroll" : 1,
		"enablevscroll" : 1,
		"devicewidth" : 0.0,
		"description" : "",
		"digest" : "",
		"tags" : "",
		"style" : "",
		"subpatcher_template" : "",
		"boxes" : [ 			{
				"box" : 				{
					"id" : "obj-37",
					"maxclass" : "toggle",
					"numinlets" : 1,
					"numoutlets" : 1,
					"outlettype" : [ "int" ],
					"parameter_enable" : 0,
					"patching_rect" : [ 579.0, 332.0, 24.0, 24.0 ],
					"presentation_rect" : [ 314.0, 345.0, 24.0, 24.0 ],
					"style" : ""
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 13.0,
					"id" : "obj-42",
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 579.0, 356.0, 61.0, 23.0 ],
					"style" : "",
					"text" : "active $1"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 12.0,
					"id" : "obj-29",
					"maxclass" : "comment",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patching_rect" : [ 819.0, 267.0, 150.0, 20.0 ],
					"style" : "",
					"text" : "transport",
					"textcolor" : [ 1.0, 1.0, 1.0, 1.0 ]
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-31",
					"maxclass" : "toggle",
					"numinlets" : 1,
					"numoutlets" : 1,
					"outlettype" : [ "int" ],
					"parameter_enable" : 0,
					"patching_rect" : [ 804.0, 357.0, 20.0, 20.0 ],
					"style" : ""
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial Bold",
					"fontsize" : 10.0,
					"id" : "obj-32",
					"maxclass" : "newobj",
					"numinlets" : 2,
					"numoutlets" : 2,
					"outlettype" : [ "", "" ],
					"patching_rect" : [ 804.0, 327.0, 130.0, 20.0 ],
					"saved_object_attributes" : 					{
						"_persistence" : 1
					}
,
					"style" : "",
					"text" : "live.observer is_playing"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial Bold",
					"fontsize" : 10.0,
					"id" : "obj-33",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 3,
					"outlettype" : [ "", "", "" ],
					"patching_rect" : [ 879.0, 297.0, 91.0, 20.0 ],
					"style" : "",
					"text" : "live.path live_set"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 12.0,
					"id" : "obj-26",
					"maxclass" : "comment",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patching_rect" : [ 353.5, 646.0, 49.0, 20.0 ],
					"style" : "",
					"text" : "bpm",
					"textcolor" : [ 1.0, 1.0, 1.0, 1.0 ]
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-9",
					"maxclass" : "button",
					"numinlets" : 1,
					"numoutlets" : 1,
					"outlettype" : [ "bang" ],
					"patching_rect" : [ 353.5, 671.0, 20.0, 20.0 ],
					"style" : ""
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial Bold",
					"fontsize" : 10.0,
					"id" : "obj-11",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 1,
					"outlettype" : [ "bang" ],
					"patching_rect" : [ 353.5, 701.0, 55.0, 20.0 ],
					"style" : "",
					"text" : "loadbang"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial Bold",
					"fontsize" : 10.0,
					"format" : 6,
					"id" : "obj-22",
					"maxclass" : "flonum",
					"numinlets" : 1,
					"numoutlets" : 2,
					"outlettype" : [ "", "bang" ],
					"parameter_enable" : 0,
					"patching_rect" : [ 353.5, 865.0, 50.0, 20.0 ],
					"style" : ""
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial Bold",
					"fontsize" : 10.0,
					"id" : "obj-20",
					"maxclass" : "newobj",
					"numinlets" : 2,
					"numoutlets" : 2,
					"outlettype" : [ "", "" ],
					"patching_rect" : [ 353.5, 841.0, 72.0, 20.0 ],
					"saved_object_attributes" : 					{
						"_persistence" : 1
					}
,
					"style" : "",
					"text" : "live.observer"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial Bold",
					"fontsize" : 10.0,
					"id" : "obj-12",
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 353.5, 809.0, 84.0, 20.0 ],
					"style" : "",
					"text" : "property tempo"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial Bold",
					"fontsize" : 10.0,
					"id" : "obj-13",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 2,
					"outlettype" : [ "bang", "" ],
					"patching_rect" : [ 353.5, 785.0, 71.5, 20.0 ],
					"style" : "",
					"text" : "t b l"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial Bold",
					"fontsize" : 10.0,
					"id" : "obj-14",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 3,
					"outlettype" : [ "", "", "" ],
					"patching_rect" : [ 353.5, 761.0, 51.0, 20.0 ],
					"style" : "",
					"text" : "live.path"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial Bold",
					"fontsize" : 10.0,
					"id" : "obj-18",
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 353.5, 737.0, 71.0, 20.0 ],
					"style" : "",
					"text" : "path live_set"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial Bold",
					"fontsize" : 13.0,
					"id" : "obj-50",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patcher" : 					{
						"fileversion" : 1,
						"appversion" : 						{
							"major" : 7,
							"minor" : 3,
							"revision" : 4,
							"architecture" : "x64",
							"modernui" : 1
						}
,
						"rect" : [ 393.0, 288.0, 476.0, 385.0 ],
						"bgcolor" : [ 0.67, 0.7, 0.72, 1.0 ],
						"bglocked" : 0,
						"openinpresentation" : 0,
						"default_fontsize" : 13.0,
						"default_fontface" : 0,
						"default_fontname" : "Arial",
						"gridonopen" : 1,
						"gridsize" : [ 15.0, 15.0 ],
						"gridsnaponopen" : 1,
						"objectsnaponopen" : 1,
						"statusbarvisible" : 2,
						"toolbarvisible" : 1,
						"lefttoolbarpinned" : 0,
						"toptoolbarpinned" : 0,
						"righttoolbarpinned" : 0,
						"bottomtoolbarpinned" : 0,
						"toolbars_unpinned_last_save" : 0,
						"tallnewobj" : 0,
						"boxanimatetime" : 200,
						"enablehscroll" : 1,
						"enablevscroll" : 1,
						"devicewidth" : 0.0,
						"description" : "",
						"digest" : "",
						"tags" : "",
						"style" : "",
						"subpatcher_template" : "",
						"boxes" : [ 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-10",
									"linecount" : 2,
									"maxclass" : "comment",
									"numinlets" : 1,
									"numoutlets" : 0,
									"patching_rect" : [ 323.0, 114.0, 153.0, 36.0 ],
									"style" : "",
									"text" : "extra2, you could do something with it as well."
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-20",
									"maxclass" : "comment",
									"numinlets" : 1,
									"numoutlets" : 0,
									"patching_rect" : [ 272.0, 114.0, 45.0, 21.0 ],
									"style" : "",
									"text" : "extra1"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-19",
									"maxclass" : "comment",
									"numinlets" : 1,
									"numoutlets" : 0,
									"patching_rect" : [ 218.0, 114.0, 33.0, 21.0 ],
									"style" : "",
									"text" : "Dur."
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-18",
									"maxclass" : "comment",
									"numinlets" : 1,
									"numoutlets" : 0,
									"patching_rect" : [ 164.0, 114.0, 31.0, 21.0 ],
									"style" : "",
									"text" : "Vel."
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-17",
									"maxclass" : "comment",
									"numinlets" : 1,
									"numoutlets" : 0,
									"patching_rect" : [ 110.0, 114.0, 37.0, 21.0 ],
									"style" : "",
									"text" : "Pitch"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-16",
									"maxclass" : "newobj",
									"numinlets" : 3,
									"numoutlets" : 0,
									"patching_rect" : [ 75.0, 347.0, 53.0, 23.0 ],
									"style" : "",
									"text" : "noteout"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-9",
									"maxclass" : "number",
									"numinlets" : 1,
									"numoutlets" : 2,
									"outlettype" : [ "", "bang" ],
									"parameter_enable" : 0,
									"patching_rect" : [ 261.0, 134.0, 50.0, 23.0 ],
									"style" : ""
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"format" : 6,
									"id" : "obj-8",
									"maxclass" : "flonum",
									"numinlets" : 1,
									"numoutlets" : 2,
									"outlettype" : [ "", "bang" ],
									"parameter_enable" : 0,
									"patching_rect" : [ 207.0, 134.0, 50.0, 23.0 ],
									"style" : ""
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-7",
									"maxclass" : "number",
									"numinlets" : 1,
									"numoutlets" : 2,
									"outlettype" : [ "", "bang" ],
									"parameter_enable" : 0,
									"patching_rect" : [ 153.0, 134.0, 50.0, 23.0 ],
									"style" : ""
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-6",
									"maxclass" : "number",
									"numinlets" : 1,
									"numoutlets" : 2,
									"outlettype" : [ "", "bang" ],
									"parameter_enable" : 0,
									"patching_rect" : [ 99.0, 134.0, 50.0, 23.0 ],
									"style" : ""
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-4",
									"maxclass" : "comment",
									"numinlets" : 1,
									"numoutlets" : 0,
									"patching_rect" : [ 56.0, 114.0, 35.0, 21.0 ],
									"style" : "",
									"text" : "Step"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-5",
									"maxclass" : "message",
									"numinlets" : 2,
									"numoutlets" : 1,
									"outlettype" : [ "" ],
									"patching_rect" : [ 207.0, 256.0, 54.0, 23.0 ],
									"style" : "",
									"text" : "$1 ticks"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-35",
									"maxclass" : "newobj",
									"numinlets" : 2,
									"numoutlets" : 1,
									"outlettype" : [ "" ],
									"patching_rect" : [ 75.0, 255.0, 42.5, 23.0 ],
									"style" : "",
									"text" : "gate"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-34",
									"maxclass" : "number",
									"numinlets" : 1,
									"numoutlets" : 2,
									"outlettype" : [ "", "bang" ],
									"parameter_enable" : 0,
									"patching_rect" : [ 45.0, 134.0, 50.0, 23.0 ],
									"style" : ""
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-33",
									"maxclass" : "newobj",
									"numinlets" : 3,
									"numoutlets" : 2,
									"outlettype" : [ "float", "float" ],
									"patching_rect" : [ 75.0, 295.0, 207.0, 23.0 ],
									"style" : "",
									"text" : "makenote 64 250 @repeatmode 1"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-30",
									"maxclass" : "newobj",
									"numinlets" : 2,
									"numoutlets" : 1,
									"outlettype" : [ "int" ],
									"patching_rect" : [ 261.0, 204.0, 42.0, 23.0 ],
									"style" : "",
									"text" : "> 0"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-29",
									"maxclass" : "newobj",
									"numinlets" : 1,
									"numoutlets" : 2,
									"outlettype" : [ "int", "bang" ],
									"patching_rect" : [ 261.0, 157.0, 42.0, 23.0 ],
									"style" : "",
									"text" : "t i b"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-28",
									"maxclass" : "newobj",
									"numinlets" : 2,
									"numoutlets" : 1,
									"outlettype" : [ "int" ],
									"patching_rect" : [ 284.0, 181.0, 79.0, 23.0 ],
									"style" : "",
									"text" : "random 100"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-27",
									"maxclass" : "newobj",
									"numinlets" : 1,
									"numoutlets" : 6,
									"outlettype" : [ "int", "int", "int", "float", "int", "int" ],
									"patching_rect" : [ 45.0, 94.0, 289.0, 23.0 ],
									"style" : "",
									"text" : "unpack 0 0 0 0. 0 0"
								}

							}
, 							{
								"box" : 								{
									"comment" : "",
									"id" : "obj-46",
									"index" : 1,
									"maxclass" : "inlet",
									"numinlets" : 0,
									"numoutlets" : 1,
									"outlettype" : [ "" ],
									"patching_rect" : [ 45.0, 30.0, 25.0, 25.0 ],
									"style" : ""
								}

							}
 ],
						"lines" : [ 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-34", 0 ],
									"source" : [ "obj-27", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-6", 0 ],
									"source" : [ "obj-27", 1 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-7", 0 ],
									"source" : [ "obj-27", 2 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-8", 0 ],
									"source" : [ "obj-27", 3 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-9", 0 ],
									"source" : [ "obj-27", 4 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-30", 1 ],
									"source" : [ "obj-28", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-28", 0 ],
									"source" : [ "obj-29", 1 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-30", 0 ],
									"source" : [ "obj-29", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-35", 0 ],
									"source" : [ "obj-30", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-16", 1 ],
									"midpoints" : [ 272.5, 326.0, 101.5, 326.0 ],
									"source" : [ "obj-33", 1 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-16", 0 ],
									"source" : [ "obj-33", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-33", 0 ],
									"source" : [ "obj-35", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-27", 0 ],
									"source" : [ "obj-46", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-33", 2 ],
									"source" : [ "obj-5", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-35", 1 ],
									"source" : [ "obj-6", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-33", 1 ],
									"source" : [ "obj-7", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-5", 0 ],
									"source" : [ "obj-8", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-29", 0 ],
									"source" : [ "obj-9", 0 ]
								}

							}
 ],
						"bgfillcolor_type" : "gradient",
						"bgfillcolor_color1" : [ 0.435294, 0.462745, 0.498039, 1.0 ],
						"bgfillcolor_color2" : [ 0.290196, 0.309804, 0.301961, 1.0 ],
						"bgfillcolor_color" : [ 0.290196, 0.309804, 0.301961, 1.0 ],
						"bgfillcolor_angle" : 270.0,
						"bgfillcolor_proportion" : 0.39
					}
,
					"patching_rect" : [ 480.0, 726.5, 104.0, 23.0 ],
					"saved_object_attributes" : 					{
						"description" : "",
						"digest" : "",
						"fontsize" : 13.0,
						"globalpatchername" : "",
						"style" : "",
						"tags" : ""
					}
,
					"style" : "",
					"text" : "p PlayMIDINote"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 13.0,
					"id" : "obj-150",
					"linecount" : 3,
					"maxclass" : "comment",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patching_rect" : [ 653.0, 774.0, 165.0, 50.0 ],
					"style" : "",
					"text" : "Current step values (list) : \nstep pitch vel. dur. (ticks) prob. extra1 extra2",
					"textcolor" : [ 1.0, 1.0, 1.0, 1.0 ]
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 13.0,
					"id" : "obj-4",
					"linecount" : 2,
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 653.0, 726.5, 139.0, 38.0 ],
					"style" : "",
					"text" : "11 60 100 120. 100 100"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 13.0,
					"id" : "obj-174",
					"maxclass" : "newobj",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patcher" : 					{
						"fileversion" : 1,
						"appversion" : 						{
							"major" : 7,
							"minor" : 3,
							"revision" : 4,
							"architecture" : "x64",
							"modernui" : 1
						}
,
						"rect" : [ 490.0, 426.0, 632.0, 331.0 ],
						"bgcolor" : [ 0.67, 0.7, 0.72, 1.0 ],
						"bglocked" : 0,
						"openinpresentation" : 0,
						"default_fontsize" : 13.0,
						"default_fontface" : 0,
						"default_fontname" : "Arial",
						"gridonopen" : 1,
						"gridsize" : [ 15.0, 15.0 ],
						"gridsnaponopen" : 1,
						"objectsnaponopen" : 1,
						"statusbarvisible" : 2,
						"toolbarvisible" : 1,
						"lefttoolbarpinned" : 0,
						"toptoolbarpinned" : 0,
						"righttoolbarpinned" : 0,
						"bottomtoolbarpinned" : 0,
						"toolbars_unpinned_last_save" : 0,
						"tallnewobj" : 0,
						"boxanimatetime" : 200,
						"enablehscroll" : 1,
						"enablevscroll" : 1,
						"devicewidth" : 0.0,
						"description" : "",
						"digest" : "",
						"tags" : "",
						"style" : "",
						"subpatcher_template" : "",
						"boxes" : [ 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-2",
									"maxclass" : "comment",
									"numinlets" : 1,
									"numoutlets" : 0,
									"patching_rect" : [ 258.0, 241.0, 218.0, 21.0 ],
									"style" : "",
									"text" : "bars beats units PPQ time signature"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-32",
									"maxclass" : "message",
									"numinlets" : 2,
									"numoutlets" : 1,
									"outlettype" : [ "" ],
									"patching_rect" : [ 305.0, 133.0, 63.0, 23.0 ],
									"style" : "",
									"text" : "tempo $1"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-29",
									"maxclass" : "message",
									"numinlets" : 2,
									"numoutlets" : 1,
									"outlettype" : [ "" ],
									"patching_rect" : [ 63.0, 143.0, 32.5, 23.0 ],
									"style" : "",
									"text" : "0."
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-24",
									"maxclass" : "newobj",
									"numinlets" : 2,
									"numoutlets" : 1,
									"outlettype" : [ "bang" ],
									"patching_rect" : [ 165.0, 93.0, 447.0, 23.0 ],
									"style" : "",
									"text" : "metro @interval 10 ticks @quantize 10 ticks @autostart 1 @autostarttime 0."
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-18",
									"maxclass" : "newobj",
									"numinlets" : 1,
									"numoutlets" : 1,
									"outlettype" : [ "" ],
									"patching_rect" : [ 165.0, 235.0, 85.0, 23.0 ],
									"style" : "",
									"text" : "prepend time"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-15",
									"maxclass" : "newobj",
									"numinlets" : 6,
									"numoutlets" : 1,
									"outlettype" : [ "" ],
									"patching_rect" : [ 165.0, 197.0, 109.0, 23.0 ],
									"style" : "",
									"text" : "pack 0 0 0. 0. 0 0"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-13",
									"maxclass" : "message",
									"numinlets" : 2,
									"numoutlets" : 1,
									"outlettype" : [ "" ],
									"patching_rect" : [ 101.0, 144.0, 37.0, 23.0 ],
									"style" : "",
									"text" : "reset"
								}

							}
, 							{
								"box" : 								{
									"comment" : "",
									"id" : "obj-9",
									"index" : 1,
									"maxclass" : "outlet",
									"numinlets" : 1,
									"numoutlets" : 0,
									"patching_rect" : [ 101.0, 273.0, 25.0, 25.0 ],
									"style" : ""
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-5",
									"maxclass" : "newobj",
									"numinlets" : 2,
									"numoutlets" : 2,
									"outlettype" : [ "bang", "" ],
									"patching_rect" : [ 101.0, 107.0, 36.0, 23.0 ],
									"style" : "",
									"text" : "sel 0"
								}

							}
, 							{
								"box" : 								{
									"fontname" : "Arial",
									"fontsize" : 13.0,
									"id" : "obj-51",
									"maxclass" : "newobj",
									"numinlets" : 2,
									"numoutlets" : 9,
									"outlettype" : [ "int", "int", "float", "float", "float", "", "int", "float", "" ],
									"patching_rect" : [ 165.0, 162.0, 153.5, 23.0 ],
									"style" : "",
									"text" : "transport"
								}

							}
, 							{
								"box" : 								{
									"comment" : "",
									"id" : "obj-75",
									"index" : 1,
									"maxclass" : "inlet",
									"numinlets" : 0,
									"numoutlets" : 1,
									"outlettype" : [ "int" ],
									"patching_rect" : [ 101.0, 55.0, 25.0, 25.0 ],
									"style" : ""
								}

							}
, 							{
								"box" : 								{
									"comment" : "",
									"id" : "obj-76",
									"index" : 2,
									"maxclass" : "inlet",
									"numinlets" : 0,
									"numoutlets" : 1,
									"outlettype" : [ "" ],
									"patching_rect" : [ 305.0, 40.0, 25.0, 25.0 ],
									"style" : ""
								}

							}
 ],
						"lines" : [ 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-9", 0 ],
									"source" : [ "obj-13", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-18", 0 ],
									"source" : [ "obj-15", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-9", 0 ],
									"midpoints" : [ 174.5, 261.0, 110.5, 261.0 ],
									"source" : [ "obj-18", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-51", 0 ],
									"source" : [ "obj-24", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-51", 1 ],
									"midpoints" : [ 72.5, 226.0, 150.0, 226.0, 150.0, 155.0, 309.0, 155.0 ],
									"source" : [ "obj-29", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-51", 0 ],
									"source" : [ "obj-32", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-13", 0 ],
									"order" : 0,
									"source" : [ "obj-5", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-29", 0 ],
									"midpoints" : [ 110.5, 138.0, 72.5, 138.0 ],
									"order" : 1,
									"source" : [ "obj-5", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-15", 4 ],
									"midpoints" : [ 258.5625, 189.0, 246.5, 189.0 ],
									"source" : [ "obj-51", 5 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-15", 3 ],
									"source" : [ "obj-51", 3 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-15", 2 ],
									"source" : [ "obj-51", 2 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-15", 1 ],
									"source" : [ "obj-51", 1 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-15", 0 ],
									"midpoints" : [ 174.5, 184.0, 174.5, 193.0 ],
									"source" : [ "obj-51", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-5", 0 ],
									"order" : 1,
									"source" : [ "obj-75", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-51", 0 ],
									"order" : 0,
									"source" : [ "obj-75", 0 ]
								}

							}
, 							{
								"patchline" : 								{
									"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
									"destination" : [ "obj-32", 0 ],
									"source" : [ "obj-76", 0 ]
								}

							}
 ],
						"bgfillcolor_type" : "gradient",
						"bgfillcolor_color1" : [ 0.435294, 0.462745, 0.498039, 1.0 ],
						"bgfillcolor_color2" : [ 0.290196, 0.309804, 0.301961, 1.0 ],
						"bgfillcolor_color" : [ 0.290196, 0.309804, 0.301961, 1.0 ],
						"bgfillcolor_angle" : 270.0,
						"bgfillcolor_proportion" : 0.39
					}
,
					"patching_rect" : [ 428.0, 329.0, 104.0, 23.0 ],
					"saved_object_attributes" : 					{
						"description" : "",
						"digest" : "",
						"fontsize" : 13.0,
						"globalpatchername" : "",
						"style" : "",
						"tags" : ""
					}
,
					"style" : "",
					"text" : "p Transportation"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 13.0,
					"id" : "obj-5",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 513.0, 270.0, 95.0, 23.0 ],
					"style" : "",
					"text" : "loadmess 120."
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 13.0,
					"id" : "obj-3",
					"maxclass" : "comment",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patching_rect" : [ 514.0, 242.0, 89.0, 21.0 ],
					"style" : "",
					"text" : "Tempo (bpm):",
					"textcolor" : [ 1.0, 1.0, 1.0, 1.0 ]
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 13.0,
					"id" : "obj-175",
					"maxclass" : "comment",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patching_rect" : [ 398.0, 270.0, 103.0, 21.0 ],
					"style" : "",
					"text" : "Transport on/off:",
					"textcolor" : [ 1.0, 1.0, 1.0, 1.0 ]
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 13.0,
					"format" : 6,
					"id" : "obj-8",
					"maxclass" : "flonum",
					"numinlets" : 1,
					"numoutlets" : 2,
					"outlettype" : [ "", "bang" ],
					"parameter_enable" : 0,
					"patching_rect" : [ 513.0, 296.0, 50.0, 23.0 ],
					"style" : ""
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-176",
					"maxclass" : "toggle",
					"numinlets" : 1,
					"numoutlets" : 1,
					"outlettype" : [ "int" ],
					"parameter_enable" : 0,
					"patching_rect" : [ 428.0, 296.0, 24.0, 24.0 ],
					"style" : ""
				}

			}
, 			{
				"box" : 				{
					"bgcolor" : [ 0.917763, 0.295848, 0.233668, 0.290933 ],
					"fontname" : "Ailerons",
					"fontsize" : 18.0,
					"id" : "obj-24",
					"maxclass" : "comment",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patching_rect" : [ 928.0, 685.0, 99.0, 24.0 ],
					"presentation" : 1,
					"presentation_rect" : [ 47.0, 42.0, 90.0, 24.0 ],
					"style" : "",
					"text" : "VRStepper",
					"textcolor" : [ 1.0, 1.0, 1.0, 1.0 ]
				}

			}
, 			{
				"box" : 				{
					"bgcolor" : [ 0.620532, 0.0, 0.084031, 0.279049 ],
					"fontsize" : 8.0,
					"id" : "obj-46",
					"maxclass" : "comment",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patching_rect" : [ 928.0, 761.0, 63.0, 15.0 ],
					"presentation" : 1,
					"presentation_rect" : [ 47.0, 176.0, 60.0, 15.0 ],
					"style" : "",
					"text" : "© APAIX 1.0",
					"textcolor" : [ 1.0, 1.0, 1.0, 1.0 ]
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-10",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 653.0, 374.0, 81.0, 22.0 ],
					"style" : "",
					"text" : "prepend step"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-15",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 2,
					"outlettype" : [ "", "FullPacket" ],
					"patching_rect" : [ 653.0, 329.0, 120.0, 22.0 ],
					"style" : "",
					"text" : "o.route /stepperData"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-41",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 653.0, 264.0, 135.0, 22.0 ],
					"style" : "",
					"text" : "udpreceive 9000 cnmat"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-40",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 82.0, 802.0, 81.0, 22.0 ],
					"style" : "",
					"text" : "prepend step"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-39",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 2,
					"outlettype" : [ "", "FullPacket" ],
					"patching_rect" : [ 82.0, 748.0, 77.0, 22.0 ],
					"style" : "",
					"text" : "o.route /step"
				}

			}
, 			{
				"box" : 				{
					"fontface" : 0,
					"fontsize" : 12.0,
					"id" : "obj-38",
					"linecount" : 2,
					"maxclass" : "o.expr.codebox",
					"numinlets" : 1,
					"numoutlets" : 2,
					"outlettype" : [ "FullPacket", "FullPacket" ],
					"patching_rect" : [ 82.0, 668.0, 215.0, 46.0 ],
					"text" : "/step = split(\" \", /value),\n/step = float32(/step)",
					"textcolor" : [ 0.0, 0.0, 0.0, 1.0 ]
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-30",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 2,
					"outlettype" : [ "", "" ],
					"patching_rect" : [ 82.0, 623.0, 163.0, 22.0 ],
					"style" : "",
					"text" : "o.listenumerate /initMessage"
				}

			}
, 			{
				"box" : 				{
					"fontface" : 0,
					"fontsize" : 12.0,
					"id" : "obj-28",
					"linecount" : 7,
					"maxclass" : "o.compose",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 82.0, 505.0, 498.0, 106.0 ],
					"saved_bundle_data" : [ 35, 98, 117, 110, 100, 108, 101, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, -96, 47, 105, 110, 105, 116, 77, 101, 115, 115, 97, 103, 101, 0, 0, 0, 0, 44, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 115, 0, 0, 0, 49, 32, 54, 50, 32, 48, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 50, 32, 54, 50, 32, 55, 49, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 0, 51, 32, 54, 50, 32, 49, 56, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 0, 52, 32, 54, 52, 32, 50, 54, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 0, 53, 32, 54, 54, 32, 54, 57, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 0, 54, 32, 54, 57, 32, 57, 49, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 0, 55, 32, 54, 54, 32, 55, 57, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 0, 56, 32, 54, 53, 32, 55, 53, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 0, 57, 32, 54, 54, 32, 54, 53, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 0, 49, 48, 32, 54, 55, 32, 52, 56, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 49, 49, 32, 54, 56, 32, 56, 51, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 49, 50, 32, 54, 53, 32, 56, 57, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 49, 51, 32, 54, 53, 32, 49, 50, 55, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 49, 52, 32, 54, 56, 32, 56, 51, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 49, 53, 32, 54, 57, 32, 55, 53, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 49, 54, 32, 55, 48, 32, 50, 32, 49, 50, 48, 46, 32, 49, 50, 55, 32, 49, 50, 55, 0, 0, 0, 0 ],
					"saved_bundle_length" : 436,
					"text" : "/initMessage : [\"1 62 0 120. 127 127\", \"2 62 71 120. 127 127\", \"3 62 18 120. 127 127\", \"4 64 26 120. 127 127\", \"5 66 69 120. 127 127\", \"6 69 91 120. 127 127\", \"7 66 79 120. 127 127\", \"8 65 75 120. 127 127\", \"9 66 65 120. 127 127\", \"10 67 48 120. 127 127\", \"11 68 83 120. 127 127\", \"12 65 89 120. 127 127\", \"13 65 127 120. 127 127\", \"14 68 83 120. 127 127\", \"15 69 75 120. 127 127\", \"16 70 2 120. 127 127\"]",
					"textcolor" : [ 0.188, 0.188, 0.188, 1.0 ]
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-27",
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 82.0, 373.5, 41.0, 22.0 ],
					"style" : "",
					"text" : "dump"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-25",
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 92.5, 458.0, 56.0, 22.0 ],
					"style" : "",
					"text" : "zoom_fit"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-23",
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 82.0, 417.0, 145.0, 22.0 ],
					"style" : "",
					"text" : "fold_pitch 60 63 67 70 74"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-19",
					"maxclass" : "live.menu",
					"numinlets" : 1,
					"numoutlets" : 3,
					"outlettype" : [ "", "", "float" ],
					"parameter_enable" : 1,
					"patching_rect" : [ 1071.0, 237.0, 119.0, 15.0 ],
					"presentation" : 1,
					"presentation_rect" : [ 47.0, 98.0, 128.0, 15.0 ],
					"saved_attribute_attributes" : 					{
						"valueof" : 						{
							"parameter_longname" : "live.menu[1]",
							"parameter_shortname" : "live.menu",
							"parameter_type" : 2,
							"parameter_enum" : [ "All", "Pitch", "Velocity", "Duration", "Extra 1 (Filter Cutoff)", "Extra 2 (Pan)" ],
							"parameter_speedlim" : 0.0
						}

					}
,
					"varname" : "live.menu[1]"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 12.0,
					"id" : "obj-21",
					"maxclass" : "newobj",
					"numinlets" : 1,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 1071.0, 258.0, 88.0, 22.0 ],
					"style" : "",
					"text" : "prepend mode"
				}

			}
, 			{
				"box" : 				{
					"fontname" : "Arial",
					"fontsize" : 12.0,
					"id" : "obj-16",
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 1203.0, 258.0, 47.0, 22.0 ],
					"style" : "",
					"text" : "fold $1"
				}

			}
, 			{
				"box" : 				{
					"automation" : "off",
					"automationon" : "on",
					"id" : "obj-17",
					"maxclass" : "live.text",
					"numinlets" : 1,
					"numoutlets" : 2,
					"outlettype" : [ "", "" ],
					"parameter_enable" : 1,
					"patching_rect" : [ 1203.0, 237.0, 40.0, 15.0 ],
					"presentation" : 1,
					"presentation_rect" : [ 47.0, 75.0, 128.0, 15.0 ],
					"saved_attribute_attributes" : 					{
						"valueof" : 						{
							"parameter_longname" : "live.text[2]",
							"parameter_shortname" : "live.text",
							"parameter_type" : 2,
							"parameter_mmax" : 1.0,
							"parameter_enum" : [ "off", "on" ],
							"parameter_initial_enable" : 1,
							"parameter_initial" : [ 1 ],
							"parameter_speedlim" : 0.0
						}

					}
,
					"text" : "Fold",
					"texton" : "Fold",
					"varname" : "live.text[1]"
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-34",
					"maxclass" : "comment",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patching_rect" : [ 82.0, 343.0, 223.0, 20.0 ],
					"style" : "",
					"text" : "Pitch, Velocity, Duration, Extra1, Extra2",
					"textcolor" : [ 1.0, 1.0, 1.0, 1.0 ]
				}

			}
, 			{
				"box" : 				{
					"id" : "obj-35",
					"maxclass" : "message",
					"numinlets" : 2,
					"numoutlets" : 1,
					"outlettype" : [ "" ],
					"patching_rect" : [ 731.5, 668.0, 131.0, 22.0 ],
					"style" : "",
					"text" : "9 67 59 120. 127 127"
				}

			}
, 			{
				"box" : 				{
					"fontface" : 0,
					"fontname" : "Arial",
					"id" : "obj-36",
					"maxclass" : "live.step",
					"numinlets" : 1,
					"numoutlets" : 5,
					"outlettype" : [ "", "", "", "", "" ],
					"parameter_enable" : 1,
					"patching_rect" : [ 653.0, 463.0, 400.0, 170.0 ],
					"presentation" : 1,
					"presentation_rect" : [ 188.0, 42.0, 469.0, 149.0 ],
					"saved_attribute_attributes" : 					{
						"valueof" : 						{
							"parameter_longname" : "live.step",
							"parameter_shortname" : "live.step",
							"parameter_type" : 3,
							"parameter_invisible" : 1
						}

					}
,
					"varname" : "live.step"
				}

			}
, 			{
				"box" : 				{
					"background" : 1,
					"id" : "obj-49",
					"maxclass" : "panel",
					"numinlets" : 1,
					"numoutlets" : 0,
					"patching_rect" : [ 917.5, 662.0, 128.0, 128.0 ],
					"presentation" : 1,
					"presentation_rect" : [ 27.0, 27.0, 640.0, 176.0 ],
					"style" : ""
				}

			}
 ],
		"lines" : [ 			{
				"patchline" : 				{
					"destination" : [ "obj-36", 0 ],
					"source" : [ "obj-10", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-18", 0 ],
					"midpoints" : [ 363.0, 724.5, 363.0, 724.5 ],
					"source" : [ "obj-11", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-20", 0 ],
					"source" : [ "obj-12", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-12", 0 ],
					"source" : [ "obj-13", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-20", 1 ],
					"source" : [ "obj-13", 1 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-13", 0 ],
					"source" : [ "obj-14", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-10", 0 ],
					"source" : [ "obj-15", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-36", 0 ],
					"midpoints" : [ 1212.5, 408.0, 662.5, 408.0 ],
					"source" : [ "obj-16", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-16", 0 ],
					"source" : [ "obj-17", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-36", 0 ],
					"midpoints" : [ 437.5, 425.0, 662.5, 425.0 ],
					"source" : [ "obj-174", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
					"destination" : [ "obj-174", 0 ],
					"source" : [ "obj-176", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-14", 0 ],
					"source" : [ "obj-18", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-21", 0 ],
					"source" : [ "obj-19", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-22", 0 ],
					"source" : [ "obj-20", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-36", 0 ],
					"midpoints" : [ 1080.5, 407.0, 662.5, 407.0 ],
					"source" : [ "obj-21", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-36", 0 ],
					"midpoints" : [ 91.5, 450.0, 662.5, 450.0 ],
					"source" : [ "obj-23", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-36", 0 ],
					"midpoints" : [ 102.0, 494.0, 456.5, 494.0, 456.5, 451.0, 662.5, 451.0 ],
					"source" : [ "obj-25", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-36", 0 ],
					"midpoints" : [ 91.5, 407.0, 662.5, 407.0 ],
					"source" : [ "obj-27", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-30", 0 ],
					"source" : [ "obj-28", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-38", 0 ],
					"source" : [ "obj-30", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-31", 0 ],
					"source" : [ "obj-32", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-32", 1 ],
					"source" : [ "obj-33", 1 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-35", 1 ],
					"source" : [ "obj-36", 2 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-4", 0 ],
					"order" : 0,
					"source" : [ "obj-36", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-50", 0 ],
					"midpoints" : [ 662.5, 703.0, 489.5, 703.0 ],
					"order" : 1,
					"source" : [ "obj-36", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
					"destination" : [ "obj-42", 0 ],
					"source" : [ "obj-37", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-39", 0 ],
					"source" : [ "obj-38", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-40", 0 ],
					"source" : [ "obj-39", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-36", 0 ],
					"midpoints" : [ 91.5, 834.0, 608.0, 834.0, 608.0, 451.0, 662.5, 451.0 ],
					"source" : [ "obj-40", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-15", 0 ],
					"source" : [ "obj-41", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-36", 0 ],
					"midpoints" : [ 588.5, 408.0, 662.5, 408.0 ],
					"source" : [ "obj-42", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
					"destination" : [ "obj-8", 0 ],
					"source" : [ "obj-5", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"color" : [ 0.501961, 0.501961, 0.501961, 0.901961 ],
					"destination" : [ "obj-174", 1 ],
					"source" : [ "obj-8", 0 ]
				}

			}
, 			{
				"patchline" : 				{
					"destination" : [ "obj-11", 0 ],
					"source" : [ "obj-9", 0 ]
				}

			}
 ],
		"parameters" : 		{
			"obj-17" : [ "live.text[2]", "live.text", 0 ],
			"obj-36" : [ "live.step", "live.step", 0 ],
			"obj-19" : [ "live.menu[1]", "live.menu", 0 ]
		}
,
		"dependency_cache" : [ 			{
				"name" : "o.compose.mxo",
				"type" : "iLaX"
			}
, 			{
				"name" : "o.listenumerate.mxo",
				"type" : "iLaX"
			}
, 			{
				"name" : "o.expr.codebox.mxo",
				"type" : "iLaX"
			}
, 			{
				"name" : "o.route.mxo",
				"type" : "iLaX"
			}
 ],
		"autosave" : 0,
		"styles" : [ 			{
				"name" : "AudioStatus_Menu",
				"default" : 				{
					"bgfillcolor" : 					{
						"type" : "color",
						"color" : [ 0.294118, 0.313726, 0.337255, 1 ],
						"color1" : [ 0.454902, 0.462745, 0.482353, 0.0 ],
						"color2" : [ 0.290196, 0.309804, 0.301961, 1.0 ],
						"angle" : 270.0,
						"proportion" : 0.39,
						"autogradient" : 0
					}

				}
,
				"parentstyle" : "",
				"multi" : 0
			}
, 			{
				"name" : "newobjBlue-1",
				"default" : 				{
					"accentcolor" : [ 0.317647, 0.654902, 0.976471, 1.0 ]
				}
,
				"parentstyle" : "",
				"multi" : 0
			}
, 			{
				"name" : "newobjGreen-1",
				"default" : 				{
					"accentcolor" : [ 0.0, 0.533333, 0.168627, 1.0 ]
				}
,
				"parentstyle" : "",
				"multi" : 0
			}
, 			{
				"name" : "newobjYellow-1",
				"default" : 				{
					"accentcolor" : [ 0.82517, 0.78181, 0.059545, 1.0 ],
					"fontsize" : [ 12.059008 ]
				}
,
				"parentstyle" : "",
				"multi" : 0
			}
 ]
	}

}
