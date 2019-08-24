using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    class ScenarioResource
    {
        private static ScenarioResource instance;
        public static ScenarioResource GetInstace()
        {
            if (instance == null)
            {
                instance = new ScenarioResource();
            }
            return instance;
        }

        private ScenarioResource()
        {

        }

        private List<Sprite[]> _characters;
        private Sprite[] _backgrounds;
        private AudioClip[] _bgms;
        private AudioClip[] _sfx;
        private TextAsset[] _jsonTexts;

        public void Load()
        {
            _jsonTexts = Resources.LoadAll<TextAsset>("Json");
            _characters = new List<Sprite[]>();
            _characters.Add(Resources.LoadAll<Sprite>("Pictures/Characters/0"));
            _characters.Add(Resources.LoadAll<Sprite>("Pictures/Characters/1"));
            _characters.Add(Resources.LoadAll<Sprite>("Pictures/Characters/2"));
            _backgrounds = Resources.LoadAll<Sprite>("Backgrounds");
            _bgms = Resources.LoadAll<AudioClip>("BGM");
            _sfx = Resources.LoadAll<AudioClip>("SFX");
        }
        
        public Sprite GetCharacter(int characterId,int id)
        {
            if (characterId < 0 || _characters.Count <= characterId) return null;
            if (id < 0 || _characters[characterId].Length <= id) return null;
            return _characters[characterId][id];
        }

        public Sprite GetBackground (int id)
        {
            if (id < 0 || _backgrounds.Length <= id) return null;
            return _backgrounds[id];
        }

        public AudioClip GetBGM(int id)
        {
            if (id < 0 || _bgms.Length <= id) return null;
            return _bgms[id];
        }

        public AudioClip GetSFX(int id)
        {
            if (id < 0 || _sfx.Length <= id) return null;
            return _sfx[id];
        }

        public JsonNode GetJSON(int id)
        {
            if (id < 0 || _jsonTexts.Length <= id) return null;
            return JsonNode.Parse(_jsonTexts[id].text);
        }
        
       
    }
}

