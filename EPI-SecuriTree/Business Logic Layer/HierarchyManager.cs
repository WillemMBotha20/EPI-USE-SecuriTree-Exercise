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
        readonly HierarchyDatabaseController con = new HierarchyDatabaseController();

        #region "CreateHierarhcy"
        //Hierarchy algorithm...
        public void CreateHiercy(TreeView view)
        {
            _ = new DataSet();
            _ = new DataSet();
            _ = new DataSet();
            _ = new DataSet();
            _ = new DataSet();
            _ = new TreeNode();
            _ = new List<TreeNode>();

            string id;

            //Improvements that can be made: Before running the algorithm create a node to base the algorithm off.

            DataSet tempSet = con.GetChildren("6C4E2C5D-BBBB-4386-AA71-B7F56727433C");

            List<TreeNode> node = CreateNode("6C4E2C5D-BBBB-4386-AA71-B7F56727433C");
            view.Nodes.Add(node[0]); //Creates the first Doors node
            view.Nodes.Add(node[1]); //Creates the first Rules node

            //Responsible for creating the child id's under the parent id.
            for (int i = 0; i < tempSet.Tables[0].Rows.Count; i++)
            {
                id = tempSet.Tables[0].Rows[i]["id"].ToString();

                //Creates a node that contains the current nodes doors and rules.
                node = CreateNode(id);

                TreeNode nodeOne = new TreeNode();
                
                //Creates door and rule nodes for the current node.
                nodeOne.Nodes.Add(node[0]);
                nodeOne.Nodes.Add(node[1]);

                //Assigning a name to the node
                try
                {
                    nodeOne.Text = con.GetName(id).Tables[0].Rows[0]["name"].ToString();
                }
                catch (Exception)
                {

                    
                }              
                             
                view.Nodes.Add(nodeOne);

                DataSet tempSetSec = con.GetChildren(id);

                for (int z = 0; z < tempSetSec.Tables[0].Rows.Count; z++)
                {

                    id = tempSetSec.Tables[0].Rows[z]["id"].ToString();

                    //Creates a node that contains the current nodes doors and rules.
                    node = CreateNode(id);

                    TreeNode nodeTwo = new TreeNode();

                    //Creates door and rule nodes for the current node.
                    nodeTwo.Nodes.Add(node[0]);
                    nodeTwo.Nodes.Add(node[1]);

                    //Assigning a name to the node
                    try
                    {
                        nodeTwo.Text = con.GetName(id).Tables[0].Rows[0]["name"].ToString();
                    }
                    catch (Exception)
                    {

                        
                    }                    

                    //This functions as the indeting but it creates a node underneath the parent node for this child node.
                    view.Nodes[i + 2].Nodes.Add(nodeTwo);

                    DataSet tempSetTh = con.GetChildren(id);

                    for (int x = 0; x < tempSetTh.Tables[0].Rows.Count; x++)
                    {

                        id = tempSetTh.Tables[0].Rows[x]["id"].ToString();

                        //Creates a node that contains the current nodes doors and rules.
                        node = CreateNode(id);

                        TreeNode nodeThree = new TreeNode();

                        //Creates door and rule nodes for the current node.
                        nodeThree.Nodes.Add(node[0]);
                        nodeThree.Nodes.Add(node[1]);

                        //Retrieve the children for the current node.
                        DataSet testing = con.GetName(id);                       

                        Console.WriteLine(testing);

                        //Assigning a name to the node
                        try
                        {
                             nodeThree.Text = con.GetName(id).Tables[0].Rows[0]["name"].ToString();
                        }
                        catch (Exception)
                        {

                           
                        }

                        //This functions as the indeting but it creates a node underneath the parent node for this child node.
                        view.Nodes[i + 2].Nodes[z + 2].Nodes.Add(nodeThree);

                        //Retrieve the children for the current node.
                        DataSet tempSetFour = con.GetChildren(id);

                        for (int y = 0; y < tempSetFour.Tables[0].Rows.Count; y++)
                        {

                            id = tempSetFour.Tables[0].Rows[y]["id"].ToString();

                            //Creates a node that contains the current nodes doors and rules.
                            node = CreateNode(id);

                            //Creates door and rule nodes for the current node.
                            TreeNode nodeFour = new TreeNode();

                            nodeFour.Nodes.Add(node[0]);
                            nodeFour.Nodes.Add(node[1]);

                            //Assigning a name to the node
                            try
                            {
                                nodeFour.Text = con.GetName(id).Tables[0].Rows[0]["name"].ToString();
                            }
                            catch (Exception)
                            {

                          
                            }

                            //This functions as the indeting but it creates a node underneath the parent node for this child node.
                            view.Nodes[i + 2].Nodes[z + 2].Nodes[y + 2].Nodes.Add(nodeFour);

                            DataSet tempSetFifth = con.GetChildren(id);

                            //The code below is for possiblity if there might be another indentaion of nodes, which wasn't the case.
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
        #endregion "CreateHierarhcy"

        #region "GetCountOfDoors"
        //Simple counting of the doors for later use.
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
        #endregion "GetCountOfDoors"

        #region "Creates a Node"
        //This method creates a node that contains a node for doors and rules seperately.
        public List<TreeNode> CreateNode(string id)
        {
            _ = new DataSet();
            _ = new DataSet();
            TreeNode doorNodes = new TreeNode(); ;
            TreeNode rulesNodes = new TreeNode(); ;
            List<string> rules = new List<string>();
            List<TreeNode> mainNode = new List<TreeNode>();

            DataSet set = con.GetDoors(id);

            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                //Retrieving the  door name.
                object temp = set.Tables[0].Rows[i]["name"];

                //Finding the door status
                string stats = set.Tables[0].Rows[i]["doorstatus"].ToString();

                //Making sure to write the correct text.

                if (stats == "open")
                {
                    stats = "(UNLOCKED)";
                }
                else
                {
                    stats = "(LOCKED)";
                }

                //Combining name and status to complete requirements.
                doorNodes.Nodes.Add(temp.ToString() + " " + stats);

                DataSet rulesSet = con.GetRules(set.Tables[0].Rows[i]["id"].ToString());

                //Finding all the rules for the id.
                for (int z = 0; z < rulesSet.Tables[0].Rows.Count; z++)
                {
                    object ruleTemp = rulesSet.Tables[0].Rows[z]["access_rules_id"];
                    string name = con.GetRuleName(ruleTemp.ToString()).Tables[0].Rows[0]["name"].ToString();
                    rules.Add(name);
                }
            }

            //Removing duplicates.
            rules = rules.Distinct().ToList();

            foreach (var item in rules)
            {               
                rulesNodes.Nodes.Add(item);
            }

            //Creating the two nodes that are going to be sent back.
            doorNodes.Text = "Doors";
            mainNode.Add(doorNodes);
            rulesNodes.Text = "Rules";
            mainNode.Add(rulesNodes);

            return mainNode;
        }
        #endregion "Creates a Nod"
    }
}
