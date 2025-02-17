#pragma checksum "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\Pages\Counter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82775c529967b1987b7aaa0c385de5b334e587c1"
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
#line 30 "C:\Marek\WSB\OOP\Blazor\BouncingBalls\BouncingBalls\Pages\Counter.razor"
       
    
    private static int currentCount = 0;
    static Timer move = new Timer();
    static Timer collission = new Timer();
    
    private const int RED_BALLS_COUNT = 1;
    private const int GREEN_BALLS_COUNT = 49;
    private int redBalls = RED_BALLS_COUNT;
    private int greenBalls = GREEN_BALLS_COUNT;
    List<MovingBall> balls = new List<MovingBall>();

    private void InitBalls(int count, bool isHit = false){
        Random random = new Random(230);
        MovingBall p;

        for (int i = 0; i < count; i++)
        {
            int x = random.Next(10,190);
            int y = random.Next(10,190);
            p = new MovingBall(x,y);
            p.color = isHit ? "#FF0000":"#ABE280";
            p.IsHit = isHit;
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
        move.Interval = 50;
        move.Elapsed += Animation;
        move.Start();

        collission.Interval = 100;
        collission.Elapsed += CollissionCheck;
        collission.Start();

        currentCount++;
    }
    private void StopAnimation()
    {
        move.Stop();
        collission.Stop();
    }

    private void Animation(object sender, EventArgs e)
    {
        currentCount++;
        
        foreach (var ball in balls)
        {
            ball.next();
        }

        InvokeAsync(StateHasChanged);

        if (balls.All((item) => item.IsHit)) {
            StopAnimation();
        }
    }

    private void CollissionCheck(object sender, EventArgs e)
    {
        int numberOfCollisions = 0;

        for (int i = 0; i < balls.Count - 1; i++)
        {
            if ((balls[i].CalculateDistance(balls[i + 1]) <= balls[i].radius ||
                balls[i].CalculateDistance(balls[i + 1]) <= balls[i + 1].radius) &&
                (!balls[i].IsHit || !balls[i + 1].IsHit))
            {
                balls[i].Hit(balls[i + 1]);
                redBalls++;
                greenBalls--;

                if (greenBalls == 0) {
                    StopAnimation();
                }

                System.Console.WriteLine($"Collision detected on position ({balls[i].x},{balls[i].y}) ({balls[i + 1].x},{balls[i + 1].y})");
                numberOfCollisions++;
            }           
        }
        System.Console.WriteLine($"Total number of collisions in this step - {numberOfCollisions}");
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
