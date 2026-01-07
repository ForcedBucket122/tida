const { defineConfig } = require("cypress");

module.exports = defineConfig({
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
    baseUrl:'https://www.automationpractice.pl/',
    redirectionLimit: 3,
    retries: {
      "runMode":1,
      "openMode":1
    },
    watchForFileChanges: true,
    chromeWebSecurity: true,
    viewportWidth:1920,
    viewportHeight:1000,
    waitForAnimations: true,
    testIsolation: false,
    chromeWebSecurity:false,
  },
});
