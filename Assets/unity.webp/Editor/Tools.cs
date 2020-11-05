using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace WebP.Editor
{
    public class Tools
    {
        private static string fileStr = "\t#include \"../WebGL/webp_src~{0}\"\n";


        [MenuItem("WebP/Gen Source File String")]
        public static string GenerateSourceFileList()
        {
            var folder = EditorUtility.OpenFolderPanel("Select Source Folder", "webp_src~", "");
            var files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            var sb = new StringBuilder();
            var dic = new Dictionary<string,string>();
            foreach (var file in files)
            {
                if (!file.EndsWith(".h"))
                {
                    continue;
                }

                
                var y = file.Replace("\\", "/");
                var i = y.IndexOf("webp_src~");
                var key = y.Split('/').Last();
                if (dic.ContainsKey(key))
                {
                    continue;
                }
                
                dic[key] = y;
                var f = y.Substring(i + "webp_src~".Length);
                sb.AppendFormat(fileStr, f);
                Debug.Log(f);
            }

            var str = "extern \"C\" {\n" + sb.ToString() + "\n}";

            Debug.Log(str);
            File.WriteAllText(EditorUtility.SaveFilePanelInProject("WebP File", "webp", "cpp", "webgl lib"), str);
            return null;
        }
    }
}