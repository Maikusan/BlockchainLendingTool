var namespace = artifacts.require("test");

module.exports = function(deployer) {
  // deployment steps
  deployer.deploy(namespace);
};