#pragma checksum "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\Pages\Counter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac70155012808ae63da0a2a1aa44d2bfd9680ab4"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BouncingBalls.Pages
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\_Imports.razor"
using BouncingBalls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\_Imports.razor"
using BouncingBalls.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\Pages\Counter.razor"
using System.Timers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\Pages\Counter.razor"
using Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\Pages\Counter.razor"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public partial class Counter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 20 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\Pages\Counter.razor"
       
    
    private static int currentCount = 0;
    private int sense = 1;
    private int x = 50, y = 50;
    static Timer mytimer = new Timer();
    List<MovingBall> balls = new List<MovingBall>();

    private void init_balls(){
        Random random = new Random(230);
        MovingBall p;

        for (int i = 0; i < 50; i++)
        {
            int x = random.Next(10,190);
            int y = random.Next(10,190);
            p = new MovingBall(x,y);
            p.color = "#ABE280";
            p.setLimitX(10,190);
            p.setLimitY(10,190);
            x=random.Next(0,4);
            y=random.Next(0,4);
            p.setVelocity(x,y);
            balls.Add(p);
        }
        
    }
    private void StartAnimation()
    {
        init_balls();
        mytimer.Interval = 50;
        mytimer.Elapsed += Animation;
        mytimer.Start();
        currentCount++;
    }
    private void StopAnimation()
    {
        mytimer.Stop();
    }

    private void Animation(object sender, EventArgs e)
    {
        currentCount++;
        
        foreach (var ball in balls)
        {
            ball.next();
        }

        InvokeAsync(StateHasChanged);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
