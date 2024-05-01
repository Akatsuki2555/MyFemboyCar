using System;
using System.Reflection;
using MSCLoader;
using UnityEngine;

namespace MyFemboyCar
{
    public class MyFemboyCar : Mod
    {
        public override string Name => "My Femboy Car"; //Your mod Name
        public override string ID => "MyFemboyCar"; //Your mod ID (unique)
        public override string Version => "1.0"; //Version of your mod
        public override string Author => "アカツキ"; //Your Username

        public override void ModSetup()
        {
            base.ModSetup();

            SetupFunction(Setup.OnLoad, Mod_Load);
        }

        private void Mod_Load()
        {
            var resource = LoadResource();

            var teimoInStore = GameObject.Find("STORE").transform.GetChild(6).GetChild(1).GetChild(0).GetChild(0)
                .gameObject;
            var teimoInStoreRenderer = teimoInStore.GetComponent<SkinnedMeshRenderer>();
            teimoInStoreRenderer.GetComponent<SkinnedMeshRenderer>().sharedMaterials = new[]
            {
                resource.LoadAsset<Material>("teimohoodie"),
                resource.LoadAsset<Material>("teimothighhighs"),
                resource.LoadAsset<Material>("teimoface")
            };

            var teimoInBike = GameObject.Find("STORE").transform.GetChild(7).GetChild(0).GetChild(2).GetChild(1)
                .GetChild(0).gameObject;
            var teimoInBikeRenderer = teimoInBike.GetComponent<SkinnedMeshRenderer>();
            teimoInBikeRenderer.sharedMaterials = new[]
            {
                resource.LoadAsset<Material>("teimohoodie"),
                resource.LoadAsset<Material>("teimothighhighs"),
                resource.LoadAsset<Material>("teimoface")
            };

            var fleetari = GameObject.Find("REPAIRSHOP").transform.GetChild(14).GetChild(8).GetChild(5).GetChild(4)
                .GetChild(0).gameObject;
            var fleetariRenderer = fleetari.GetComponent<SkinnedMeshRenderer>();
            fleetariRenderer.sharedMaterials = new[]
            {
                resource.LoadAsset<Material>("fleetarihoodie"),
                resource.LoadAsset<Material>("fleetarithighhighs"),
                resource.LoadAsset<Material>("fleetariface")
            };

            resource.Unload(false);
            ModConsole.Print("My Femboy Car loaded!");
        }

        private AssetBundle LoadResource()
        {
            byte[] data;

            using (var stream = Assembly.GetExecutingAssembly()
                       .GetManifestResourceStream($"MyFemboyCar.myfemboymsc.unity3d"))
            {
                if (stream == null) throw new Exception("Could not load resource");
                data = new byte[stream.Length];
                _ = stream.Read(data, 0, data.Length);
            }

            return AssetBundle.CreateFromMemoryImmediate(data);
        }
    }
}