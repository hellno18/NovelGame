using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class PlayBGMCommand : BaseCommand
    {
        public PlayBGMCommand(
            GameObject root,
            IDictionary command) : base(root, command)
        {

        }
    }
}
