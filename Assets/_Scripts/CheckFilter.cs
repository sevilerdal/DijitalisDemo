using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFilter : Singleton<CheckFilter>
{
    [SerializeField] private FilterByExp filExp;
    [SerializeField] private FilterByWeight filWght;
    [SerializeField] private FilterByContent filCon;
    GlowFilter filter;
    private void Start()
    {
        filter = GlowFilter.Instance;
    }
    public void CheckF()
    {
        if (filter.wghtFilOn)
        {
            filWght.FilterWght();
        }
        else if (filter.conFilOn)
        {
            filCon.FilterCon();
        }
        else if (filter.expFilOn)
        {
            filExp.FilterExp();
        }
    }
}
