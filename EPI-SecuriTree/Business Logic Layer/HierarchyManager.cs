using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPI_SecuriTree
{
    class HierarchyManager
    {
        HierarchyDatabaseController con = new HierarchyDatabaseController();

        public void CreateHiercy(TreeView view)
        {            
            DataSet tempSet = new DataSet();
            DataSet tempSetSec = new DataSet();
            DataSet tempSetTh = new DataSet();
            DataSet tempSetFour = new DataSet();
            DataSet tempSetFifth = new DataSet();
            TreeNode tNode;
            List<TreeNode> node = new List<TreeNode>();
            string id;

            tempSet = con.GetChildren("6C4E2C5D-BBBB-4386-AA71-B7F56727433C");
            tNode = view.Nodes.Add("Wonka Factory");

            node = CreateNode("6C4E2C5D-BBBB-4386-AA71-B7F56727433C");
            view.Nodes.Add(node[0]);
            view.Nodes.Add(node[1]);

            for (int i = 0; i < tempSet.Tables[0].Rows.Count; i++)
            {
                id = tempSet.Tables[0].Rows[i]["id"].ToString();
                node = CreateNode(id);
                view.Nodes.Add(node[0]);
                view.Nodes.Add(node[1]);

                tempSetSec = con.GetChildren(id);

                for (int z = 0; z < tempSetSec.Tables[0].Rows.Count; z++)
                {
                    try
                    {
                        id = tempSetSec.Tables[0].Rows[z]["id"].ToString();
                        node = CreateNode(id);
                        view.Nodes[z].Nodes.Add(node[0]);
                        view.Nodes[z].Nodes.Add(node[1]);

                        tempSetTh = con.GetChildren(id);

                        for (int x = 0; x < tempSetTh.Tables[0].Rows.Count; x++)
                        {
                            try
                            {
                                id = tempSetTh.Tables[0].Rows[x]["id"].ToString();
                                node = CreateNode(id);
                                view.Nodes[x].Nodes.Add(node[0]);
                                view.Nodes[x].Nodes.Add(node[1]);

                                tempSetFour = con.GetChildren(id);

                                for (int y = 0; y < tempSetFour.Tables[0].Rows.Count; y++)
                                {
                                    try
                                    {
                                        id = tempSetFour.Tables[0].Rows[y]["id"].ToString();
                                        node = CreateNode(id);
                                        view.Nodes[y].Nodes.Add(node[0]);
                                        view.Nodes[y].Nodes.Add(node[1]);

                                        tempSetFifth = con.GetChildren(id);

                                        for (int h = 0; x < tempSetFifth.Tables[0].Rows.Count; h++)
                                        {
                                            try
                                            {
                                                id = tempSetFifth.Tables[0].Rows[h]["id"].ToString();
                                                node = CreateNode(id);
                                                view.Nodes[h].Nodes.Add(node[0]);
                                                view.Nodes[h].Nodes.Add(node[1]);
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("No Childern!");
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("No Childern!");
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No Childern!");
                            }
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No Childern!");                        
                    }                   
                }
            }                       
        }

        public List<TreeNode> CreateNode(string id)
        {           
            DataSet set = new DataSet();
            DataSet rulesSet = new DataSet();
            TreeNode doorNodes = new TreeNode(); ;
            TreeNode rulesNodes = new TreeNode(); ;
            List<string> rules = new List<string>();
            List<TreeNode> mainNode = new List<TreeNode>();

            set = con.GetDoors(id);

            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                object temp = set.Tables[0].Rows[i]["name"]; 
                doorNodes.Nodes.Add(temp.ToString());

                rulesSet = con.GetRules(set.Tables[0].Rows[i]["id"].ToString());

                for (int z = 0; z < rulesSet.Tables[0].Rows.Count; z++)
                {
                    object ruleTemp = rulesSet.Tables[0].Rows[z]["access_rules_id"];
                    rules.Add(ruleTemp.ToString());
                }
            }            

            foreach (var item in rules)
            {
                rulesNodes.Nodes.Add(item);
            }

            doorNodes.Text = "Doors";
            mainNode.Add(doorNodes);
            rulesNodes.Text = "Rules";
            mainNode.Add(rulesNodes);

            return mainNode;
        }
    }

    
}
