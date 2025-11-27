import { test, expect } from '@playwright/test';

test('Click each button one-by-one with delay', async ({ page }) => {
    // Replace with your MudBlazor app's URL!
    await page.goto('https://localhost:7017/Raja-fr/EditBasket?BasketId=P0152946');

    // Find all button elements on the page
    const buttons = page.locator('button');

    // Get the count of buttons found
    const count = await buttons.count();

    for (let i = 0; i < count; i++) {
        // Select the i-th button
        const button = buttons.nth(i);

        // Optionally, print info for debugging (button text or state)
        const buttonText = await button.textContent();
        console.log(`Clicking button #${i + 1}: "${buttonText?.trim()}"`);

        // Click the button
        await button.click();

        // Wait for 500 milliseconds before clicking the next
        await page.waitForTimeout(500);
    }

    // Optionally, assert something after all clicks
    // Example: expect some result, new UI, etc. (customize as needed)
});
