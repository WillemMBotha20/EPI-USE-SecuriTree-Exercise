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
            TreeNode tNode = new TreeNode();
            List<TreeNode> node = new List<TreeNode>();
            
            string id;

            tempSet = con.GetChildren("6C4E2C5D-BBBB-4386-AA71-B7F56727433C");
                       
            node = CreateNode("6C4E2C5D-BBBB-4386-AA71-B7F56727433C");
            view.Nodes.Add(node[0]);
            view.Nodes.Add(node[1]);

            for (int i = 0; i < tempSet.Tables[0].Rows.Count; i++)
            {
                id = tempSet.Tables[0].Rows[i]["id"].ToString();
                node = CreateNode(id);

                TreeNode nodeOne = new TreeNode();

                nodeOne.Nodes.Add(node[0]);
                nodeOne.Nodes.Add(node[1]);

                try
                {
                    nodeOne.Text = con.GetName(id).Tables[0].Rows[0]["name"].ToString();
                }
                catch (Exception)
                {

                    
                }              
                             
                view.Nodes.Add(nodeOne);

                tempSetSec = con.GetChildren(id);

                for (int z = 0; z < tempSetSec.Tables[0].Rows.Count; z++)
                {

                    id = tempSetSec.Tables[0].Rows[z]["id"].ToString();

                    node = CreateNode(id);

                    TreeNode nodeTwo = new TreeNode();

                    nodeTwo.Nodes.Add(node[0]);
                    nodeTwo.Nodes.Add(node[1]);

                    try
                    {
                        nodeTwo.Text = con.GetName(id).Tables[0].Rows[0]["name"].ToString();
                    }
                    catch (Exception)
                    {

                        
                    }                    

                    view.Nodes[i + 2].Nodes.Add(nodeTwo);

                    tempSetTh = con.GetChildren(id);

                    for (int x = 0; x < tempSetTh.Tables[0].Rows.Count; x++)
                    {

                        id = tempSetTh.Tables[0].Rows[x]["id"].ToString();
                        node = CreateNode(id);

                        TreeNode nodeThree = new TreeNode();

                        nodeThree.Nodes.Add(node[0]);
                        nodeThree.Nodes.Add(node[1]);

                        DataSet testing = con.GetName(id);                       

                        Console.WriteLine(testing);

                        try
                        {
                             nodeThree.Text = con.GetName(id).Tables[0].Rows[0]["name"].ToString();
                        }
                        catch (Exception)
                        {

                           
                        }                       

                        view.Nodes[i + 2].Nodes[z + 2].Nodes.Add(nodeThree);

                        tempSetFour = con.GetChildren(id);

                        for (int y = 0; y < tempSetFour.Tables[0].Rows.Count; y++)
                        {

                            id = tempSetFour.Tables[0].Rows[y]["id"].ToString();
                            node = CreateNode(id);

                            TreeNode nodeFour = new TreeNode();

                            nodeFour.Nodes.Add(node[0]);
                            nodeFour.Nodes.Add(node[1]);

                            try
                            {
                                nodeFour.Text = con.GetName(id).Tables[0].Rows[0]["name"].ToString();
                            }
                            catch (Exception)
                            {

                          
                            }                            

                            view.Nodes[i + 2].Nodes[z + 2].Nodes[y + 2].Nodes.Add(nodeFour);

                            tempSetFifth = con.GetChildren(id);                           

                            for (int h = 0; x < tempSetFifth.Tables[0].Rows.Count; h++)
                            {

                                id = tempSetFifth.Tables[0].Rows[h]["id"].ToString();
                                node = CreateNode(id);

                                TreeNode nodeFive = new TreeNode();

                                nodeFive.Nodes.Add(node[0]);
                                nodeFive.Nodes.Add(node[1]);

                                nodeFive.Text = con.GetName(id).Tables[0].Rows[0]["name"].ToString();

                                view.Nodes[i + 2].Nodes[z].Nodes[x].Nodes[y].Nodes.Add(nodeFive);

                            }

                        }

                    }

                }
            }
        }

        public List<string> GetCount()
        {
            List<string> amount = new List<string>();

            int open = con.DoorsOpen();
            int closed = con.DoorsClosed();
            int total = open + closed;

            amount.Add(open.ToString());
            amount.Add(closed.ToString());
            amount.Add(total.ToString());

            return amount;
           
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

                string stats = set.Tables[0].Rows[i]["doorstatus"].ToString();

                if (stats == "open")
                {
                    stats = "(UNLOCKED)";
                }
                else
                {
                    stats = "(LOCKED)";
                }

                doorNodes.Nodes.Add(temp.ToString() + " " + stats);

                rulesSet = con.GetRules(set.Tables[0].Rows[i]["id"].ToString());

                for (int z = 0; z < rulesSet.Tables[0].Rows.Count; z++)
                {
                    object ruleTemp = rulesSet.Tables[0].Rows[z]["access_rules_id"];
                    string name = con.GetRuleName(ruleTemp.ToString()).Tables[0].Rows[0]["name"].ToString();
                    rules.Add(name);
                }
            }

            rules = rules.Distinct().ToList();

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
