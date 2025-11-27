using Microsoft.Playwright;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;

namespace MyOrder.Tests.InteractionTestsCSharp;

public class RunWorkers
{
    [Fact]
    public async Task SimulateMultipleUsers()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

        var tasks = new List<Task>();

        int userCount = 10;
        var random = new Random();

        for (int i = 0; i < userCount; i++)
        {
            int pageLiveTimeSeconds = random.Next(360, 600); // Random time between 1 to 3 minutes
            tasks.Add(SimulateUser(browser, i + 1, pageLiveTimeSeconds));
        }
        await Task.WhenAll(tasks);
    }

    private static async Task SimulateUser(IBrowser browser, int userId, int pageLiveTimeSeconds)
    {
        // I can add here a delay to late some users if needed.

        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        Console.WriteLine($"User {userId} opening page...");
        await page.GotoAsync("https://localhost:7017/Raja-fr/EditBasket?BasketId=P0152946");

        var random = new Random();
        var width = 800;  // Your viewport width or arbitrarily chosen area
        var height = 600; // Your viewport height or arbitrarily chosen area
        var endTime = DateTime.Now.AddSeconds(pageLiveTimeSeconds);

        while (DateTime.Now < endTime)
        {
            // Generate random coordinates within the viewport
            var x = random.Next(0, width);
            var y = random.Next(0, height);

            // Move mouse to random coordinates
            await page.Mouse.MoveAsync(x, y);

            var randomDouble = random.NextDouble();
            // Randomly decide whether to click at the current position (e.g., 20% chance)
            if (randomDouble < 0.15)
            {
                await page.Mouse.ClickAsync(x, y);
                await Task.Delay(2000);
            }

            else if (randomDouble >= 0.15 && randomDouble < 0.2)
            {
                await InteractWithRandomCheckbox(page, random);
            }
            else if (randomDouble >= 0.2 && randomDouble < 0.35)
            {
                await InteractWithRandomDatePicker(page, random, userId);
            }
            else if (randomDouble >= 0.35 && randomDouble < 0.5)
            {
                await InteractWithRandomRadio(page, random);
            }
            else if (randomDouble >= 0.5 && randomDouble < 0.65)
            {
                await InteractWithRandomInput(page, random, userId);
            }
            else if (randomDouble >= 0.65 && randomDouble < 0.8)
            {
                await ClickRandomButton(page, random);
            }
            else if (randomDouble >= 0.8 && randomDouble < 0.95)
            {
                await InteractWithRandomSelect(page, random, userId);
            }

            // Wait a bit before next move (random delay 200-800 ms)
            await Task.Delay(random.Next(200, 800));
        }

        await page.CloseAsync();
        await context.CloseAsync();
    }

    private static async Task InteractWithRandomDatePicker(IPage page, Random random, int userId) // Recap
    {
        // MudDatePicker inputs (looking for date picker specific inputs)
        var datePickers = await page.QuerySelectorAllAsync(".mud-picker input[type='text']:not([readonly]):not([disabled])");

        if (datePickers.Count > 0)
        {
            try
            {
                var randomDatePicker = datePickers[random.Next(datePickers.Count)];
                await randomDatePicker.ScrollIntoViewIfNeededAsync();

                // Click to open the date picker calendar
                await randomDatePicker.ClickAsync();

                Console.WriteLine($"User {userId} opened a MudDatePicker");

                // Wait for calendar to appear
                await page.WaitForSelectorAsync(".mud-picker-calendar", new PageWaitForSelectorOptions
                {
                    Timeout = 2000,
                    State = WaitForSelectorState.Visible
                });

                // I chose either click a day or navigate to another month

                // Navigate to a different month
                if (random.NextDouble() < 0.5)
                {
                    // Navigate forward or backward
                    if (random.NextDouble() < 0.5)
                    {
                        var nextButton = await page.QuerySelectorAsync(".mud-picker-calendar-header-switch button:last-child");
                        if (nextButton != null)
                        {
                            await nextButton.ClickAsync();
                            await Task.Delay(300); // Wait for calendar to update
                        }
                    }
                    else
                    {
                        var prevButton = await page.QuerySelectorAsync(".mud-picker-calendar-header-switch button:first-child");
                        if (prevButton != null)
                        {
                            await prevButton.ClickAsync();
                            await Task.Delay(300); // Wait for calendar to update
                        }
                    }

                }

                // Get all available (not disabled) days in the current month view
                await GetAvailableDaysOfCalendar(page, random, userId);

            }
            catch (TimeoutException)
            {
                Console.WriteLine($"User {userId} - DatePicker calendar did not open");
                await page.Keyboard.PressAsync("Escape");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"User {userId} - Error with DatePicker: {ex.Message}");
                await page.Keyboard.PressAsync("Escape");
            }
        }
    }

    private static async Task GetAvailableDaysOfCalendar(IPage page, Random random, int userId)
    {
        // Get all available (not disabled) days in the current month view
        var availableDays = await page.QuerySelectorAllAsync(".mud-picker-calendar-day:not(.mud-disabled):not(.mud-picker-calendar-day-outside-month)");

        if (availableDays.Count > 0)
        {
            // Pick a random day from the visible calendar
            var randomDay = availableDays[random.Next(availableDays.Count)];
            await randomDay.ClickAsync();

            Console.WriteLine($"User {userId} selected a random date from calendar");
        }
        else
        {
            // I can move the cursor away and click

            Console.WriteLine($"User {userId} - No available days found in calendar");
            // Generate random coordinates within the viewport
            var x = random.Next(0, 800);
            var y = random.Next(0, 600);

            // Move mouse to random coordinates
            await page.Mouse.MoveAsync(x, y);
        }
    }

    private static async Task InteractWithRandomCheckbox(IPage page, Random random)
    {
        var checkboxes = await page.QuerySelectorAllAsync(".mud-checkbox input[type='checkbox']:not([disabled])");

        if (checkboxes.Count > 0)
        {
            var randomCheckbox = checkboxes[random.Next(checkboxes.Count)];
            await randomCheckbox.ScrollIntoViewIfNeededAsync();
            await randomCheckbox.ClickAsync();
        }
    }

    private static async Task InteractWithRandomRadio(IPage page, Random random)
    {
        var radios = await page.QuerySelectorAllAsync(".mud-radio input[type='radio']:not([disabled])");
        if (radios.Count > 0)
        {
            var randomRadio = radios[random.Next(radios.Count)];
            await randomRadio.ScrollIntoViewIfNeededAsync();
            await randomRadio.ClickAsync();
        }
    }


    private static async Task ClickRandomButton(IPage page, Random random)
    {
        try
        {
            var dialogButtons = await page.QuerySelectorAllAsync(".mud-dialog-container button:not([disabled])");

            if (dialogButtons.Count > 0)
            {
                var randomDialogButton = dialogButtons[random.Next(dialogButtons.Count)];

                // Set 5-second timeout
                await randomDialogButton.ClickAsync(new ElementHandleClickOptions { Timeout = 5000 });

                await Task.Delay(500);
                return;
            }

            var buttons = await page.QuerySelectorAllAsync("button:not([disabled])");

            if (buttons.Count > 0)
            {
                var randomButton = buttons[random.Next(buttons.Count)];
                await randomButton.ScrollIntoViewIfNeededAsync();

                // Set 5-second timeout
                await randomButton.ClickAsync(new ElementHandleClickOptions { Timeout = 5000 });
                await Task.Delay(500);
            }
        }

        catch (TimeoutException)
        {
            await page.Keyboard.PressAsync("Escape");
        }
        catch (Exception ex)
        {
            await page.Keyboard.PressAsync("Escape");
        }
    }

    private static async Task InteractWithRandomSelect(IPage page, Random random, int userId)
    {
        try
        {
            var selects = await page.QuerySelectorAllAsync(".mud-select input");

            if (selects.Count > 0)
            {
                var randomSelect = selects[random.Next(selects.Count)];

                await randomSelect.ScrollIntoViewIfNeededAsync();
                await randomSelect.ClickAsync();

                await Task.Delay(500); // Wait for options to appear

                // select all non-selected items
                var selectedItems = await page.QuerySelectorAllAsync(".mud-list-item:not(.mud-selected-item)");
                if (selectedItems.Count > 0)
                {
                    var randomItem = selectedItems[random.Next(selectedItems.Count)];
                    await randomItem.ScrollIntoViewIfNeededAsync();
                    await randomItem.ClickAsync();
                }
                else
                {
                    await page.Mouse.ClickAsync(100, 100); // Click outside to close the dropdown
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"User {userId} - Error with Select: {ex.Message}");
            await page.Keyboard.PressAsync("Escape");
        }
    }


    private static async Task InteractWithRandomInput(IPage page, Random random, int userId)
    {
        var inputs = await page.QuerySelectorAllAsync(".mud-input-root input[type='text']:not([readonly]):not([disabled]), " +
                                                      ".mud-input-root input[type='email']:not([readonly]):not([disabled]), " +
                                                      ".mud-input-root input[type='number']:not([readonly]):not([disabled]), " +
                                                      ".mud-input-root input[type='date']:not([readonly]):not([disabled]), " +
                                                      ".mud-input-root input[type='time']:not([readonly]):not([disabled]), " +  // MudTimePicker
                                                      ".mud-input-root input[type='tel']:not([readonly]):not([disabled]), " +   // Phone/Tel inputs
                                                      ".mud-input-root input[type='url']:not([readonly]):not([disabled]), " +   // URL inputs
                                                      ".mud-input-root input[type='search']:not([readonly]):not([disabled]), " + // Search inputs
                                                      ".mud-input-root input[type='password']:not([readonly]):not([disabled]), " + // Password fields
                                                      ".mud-input-root textarea:not([readonly]):not([disabled])");

        if (inputs.Count > 0)
        {
            var randomInput = inputs[random.Next(inputs.Count)];
            await randomInput.ScrollIntoViewIfNeededAsync();

            // clear existing text


            //Determine the input type
            var inputType = await randomInput.GetAttributeAsync("type");
            var tagName = await randomInput.EvaluateAsync<string>("el => el.tagName.toLowerCase()");// why this code

            // Generate appropriate random text based on input type
            string textToFill = inputType switch
            {
                "email" => GenerateRandomEmail(random),
                "number" => GenerateRandomNumber(random).ToString(), // can i just use this : random.Next(1, 100).ToString(), and ToString in necessarry
                "date" => GenerateRandomDate(random),
                "time" => GenerateRandomTime(random),
                "tel" => GenerateRandomPhoneNumber(random),
                "url" => GenerateRandomUrl(random),
                "search" => GenerateRandomSearchTerm(random),
                "password" => GenerateRandomPassword(random),
                _ when tagName == "textarea" => GenerateRandomLongText(random),
                _ => GenerateRandomText(random)

            };

            // Fill the input with generated text
            await randomInput.FillAsync(textToFill);
        }
    }

    //Done
    private static string GenerateRandomEmail(Random random)
    {
        var domains = new[] { "example.com", "test.org", "demo.net", "mail.com" };
        var user = $"user{random.Next(1000, 9999)}";
        var domain = domains[random.Next(domains.Length)];
        return $"{user}@{domain}";
    }

    // Done
    private static int GenerateRandomNumber(Random random)
    {
        return random.Next(1, 1000);
    }

    // Done
    private static string GenerateRandomDate(Random random)
    {
        // Generate a random date within the next year
        var today = DateTime.Today;
        var daysToAdd = random.Next(0, 365);
        var randomDate = today.AddDays(daysToAdd);

        // Format as yyyy-MM-dd (standard HTML5 date input format)
        return randomDate.ToString("yyyy-MM-dd");
    }

    // Done
    private static string GenerateRandomTime(Random random) // Maybe i will delete this method
    {
        int hour = random.Next(0, 24);
        int minute = random.Next(0, 60);
        return $"{hour:D2}:{minute:D2}";
    }

    // Done
    private static string GenerateRandomPhoneNumber(Random random)
    {
        return $"{random.Next(100, 999)}-{random.Next(100, 999)}-{random.Next(1000, 9999)}";

    }

    // Done
    private static string GenerateRandomUrl(Random random)
    {
        var domains = new[] { "example.com", "testsite.com", "mywebsite.org" };
        return $"https://www.{domains[random.Next(domains.Length)]}/page{random.Next(1, 100)}";
    }

    // Done
    private static string GenerateRandomSearchTerm(Random random)
    {
        var terms = new[] { "CAS158", "CAS24", "CAS36", "CAS74" };
        return terms[random.Next(terms.Length)];
    }

    // Done
    private static string GenerateRandomPassword(Random random)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
        return new string(Enumerable.Repeat(chars, 6)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    //Done
    private static string GenerateRandomLongText(Random random)
    {
        var sentences = new[]
     {
        "This is a sample text for testing purposes.",
        "Please let me know if you need any further information.",
        "I’m looking forward to your feedback.",
        "MudBlazor is a great component library for Blazor applications."
    };
        var sentence = sentences[random.Next(sentences.Length)];
        return $"{sentence} Generated at {DateTime.Now:HH:mm:ss}";
    }


    //done
    private static string GenerateRandomText(Random random)
    {
        var words = new[] { "Sample", "Demo", "Example", "Test", "Input", "Value", "Data" };
        var word = words[random.Next(words.Length)];
        var number = random.Next(1, 999);
        return $"{word}{number}";
    }


}
