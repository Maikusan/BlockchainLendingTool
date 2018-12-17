using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.ABI.Encoders;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Xunit;
using Nethereum.Web3.Accounts.Managed;

namespace LendingToolMVC.Helpers
{
    public class EtheriumHelper
    {
        public void Vote()
        {
            //The URL endpoint for the blockchain network.
            var url = "HTTP://localhost:7545";

            //The contract address.
            var address = "0xb4078b136ab05bc48488eed152b7afc656747b04";

            //The ABI for the contract.
            var ABI = @"[{'constant':true,'inputs':[],'name':'candidate1','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'candidate','type':'uint256'}],'name':'castVote','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'candidate2','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'voted','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'}]";

            //Creates the connecto to the network and gets an instance of the contract.
            var web3 = new Web3(url);
            var voteContract = web3.Eth.GetContract(ABI, address);

            //Reads the vote count for Candidate 1 and Candidate 2
            var candidate1Function = voteContract.GetFunction("candidate1").CallAsync<BigInteger>();
            candidate1Function.Wait();
            var candidate1 = (int)candidate1Function.Result;
            var candidate2Function = voteContract.GetFunction("candidate2").CallAsync<BigInteger>();
            candidate2Function.Wait();
            var candidate2 = (int)candidate2Function.Result;
            Console.WriteLine("Candidate 1 votes: {0}", candidate1);
            Console.WriteLine("Candidate 2 votes: {0}", candidate2);

            //Prompts for the account address.
            Console.Write("Enter the address of your account: ");
            var accountAddress = Console.ReadLine();

            //Prompts for the users vote.
            var vote = 0;
            Console.Write("Press 1 to vote for candidate 1, Press 2 to vote for candidate 2: ");
            Int32.TryParse(Convert.ToChar(Console.Read()).ToString(), out vote);
            Console.WriteLine("You pressed {0}", vote);

            //Executes the vote on the contract.
            try
            {
                var gas = new HexBigInteger(new BigInteger(400000));
                var value = new HexBigInteger(new BigInteger(0));
                var castVoteFunction = voteContract.GetFunction("castVote").SendTransactionAsync(accountAddress, gas, value, vote);
                castVoteFunction.Wait();
                Console.WriteLine("Vote Cast!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }



        public async Task ShouldBeAbleToEncodeDecodeComplexInputOutput()
        {
            var senderAddress = "0x36BE568F38Ec9a0e5E49b775A908Dab35360167a";
            var rentalAddress = "0xb334F2Da6ed3cA1c564b151A6a260aDc15CDf596";
            var password = "8d1dfaaaf3410f15e4eb0bf6b9f9512824d011547e2e68f6bbbe6b7ed378436c";

            var abi =
                @"[ { 'constant': true, 'inputs': [ { 'name': '', 'type': 'bytes32' }, { 'name': '', 'type': 'uint256' } ], 'name': 'rentals', 'outputs': [ { 'name': 'landlord', 'type': 'address' }, { 'name': 'tenant', 'type': 'address' }, { 'name': 'depositeAmount', 'type': 'uint256' }, { 'name': 'rentalPrice', 'type': 'uint256' }, { 'name': 'endtime', 'type': 'uint256' }, { 'name': 'itemId', 'type': 'uint256' } ], 'payable': false, 'stateMutability': 'view', 'type': 'function' }, { 'constant': false, 'inputs': [ { 'name': 'key', 'type': 'bytes32' }, { 'name': 'landlord', 'type': 'address' }, { 'name': 'depositeAmount', 'type': 'uint256' }, { 'name': 'rentalPrice', 'type': 'uint256' }, { 'name': 'endtime', 'type': 'uint256' }, { 'name': 'itemId', 'type': 'uint256' } ], 'name': 'StoreRental', 'outputs': [ { 'name': 'success', 'type': 'bool' } ], 'payable': false, 'stateMutability': 'nonpayable', 'type': 'function' } ]";

            var byteCode =
                "0x608060405234801561001057600080fd5b50610447806100206000396000f30060806040526004361061004c576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680630a8d65b614610051578063152aa7ca1461011b575b600080fd5b34801561005d57600080fd5b5061008a6004803603810190808035600019169060200190929190803590602001909291905050506101ac565b604051808773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001858152602001848152602001838152602001828152602001965050505050505060405180910390f35b34801561012757600080fd5b506101926004803603810190808035600019169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190803590602001909291908035906020019092919080359060200190929190505050610244565b604051808215151515815260200191505060405180910390f35b6000602052816000526040600020818154811015156101c757fe5b9060005260206000209060060201600091509150508060000160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060010160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060020154908060030154908060040154908060050154905086565b600061024e6103b8565b60c0604051908101604052808873ffffffffffffffffffffffffffffffffffffffff1681526020013373ffffffffffffffffffffffffffffffffffffffff1681526020018781526020018681526020018581526020018481525090506000808960001916600019168152602001908152602001600020819080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060208201518160010160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060408201518160020155606082015181600301556080820151816004015560a0820151816005015550505060019150509695505050505050565b60c060405190810160405280600073ffffffffffffffffffffffffffffffffffffffff168152602001600073ffffffffffffffffffffffffffffffffffffffff1681526020016000815260200160008152602001600081526020016000815250905600a165627a7a72305820dfeb2f0f92f01e63c77c245a21f721864d33077e40ee06fcfdccb6c2c38b0e5c0029";


            //a managed account uses personal_sendTransanction with the given password, this way we don't need to unlock the account for a certain period of time
            var account = new ManagedAccount(senderAddress, password);

            //using the specific geth web3 library to allow us manage the mining.
            var web3 = new Nethereum.Web3.Web3("http://127.0.0.1:7545");
            var receipt = new TransactionReceipt();
            try
            {
                receipt = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(byteCode, senderAddress, new HexBigInteger(900000));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           


            var contractAddress = receipt.ContractAddress;

            var contract = web3.Eth.GetContract(abi, contractAddress);

            var storeFunction = contract.GetFunction("StoreRental");
            var documentsFunction = contract.GetFunction("rentals");
            var t = new Bytes32TypeEncoder();

            try
            {
                var transactionHash = await storeFunction.SendTransactionAsync(from: senderAddress, gasPrice: null, gas: new HexBigInteger(2100000), value: null, functionInput: new object[] {"key1", rentalAddress, 1, 1, 1, 1});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                var transactionHash = await storeFunction.SendTransactionAsync(from: senderAddress, gasPrice: null, gas: new HexBigInteger(2100000), value: null, functionInput: new object[] { "key1", rentalAddress, 5, 5, 5, 5 });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            var result = new Rental();
            try
            {
                result = await documentsFunction.CallDeserializingToObjectAsync<Rental>("key1", 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            var result2 = await documentsFunction.CallDeserializingToObjectAsync<Rental>("key1", 1);

            Assert.Equal("hello", result.Landlord);
            Assert.Equal("solidity is great", result.Tenant);

            Assert.Equal("hello again", result2.Landlord);
            Assert.Equal("ethereum is great", result2.Tenant);
        }

        public async Task AddRentalContract(Rental rental, string password)
        {

            var abi =
                @"[ { 'constant': true, 'inputs': [ { 'name': '', 'type': 'bytes32' }, { 'name': '', 'type': 'uint256' } ], 'name': 'rentals', 'outputs': [ { 'name': 'landlord', 'type': 'address' }, { 'name': 'tenant', 'type': 'address' }, { 'name': 'depositeAmount', 'type': 'uint256' }, { 'name': 'rentalPrice', 'type': 'uint256' }, { 'name': 'endtime', 'type': 'uint256' }, { 'name': 'itemId', 'type': 'uint256' } ], 'payable': false, 'stateMutability': 'view', 'type': 'function' }, { 'constant': false, 'inputs': [ { 'name': 'key', 'type': 'bytes32' }, { 'name': 'landlord', 'type': 'address' }, { 'name': 'depositeAmount', 'type': 'uint256' }, { 'name': 'rentalPrice', 'type': 'uint256' }, { 'name': 'endtime', 'type': 'uint256' }, { 'name': 'itemId', 'type': 'uint256' } ], 'name': 'StoreRental', 'outputs': [ { 'name': 'success', 'type': 'bool' } ], 'payable': false, 'stateMutability': 'nonpayable', 'type': 'function' } ]";

            var byteCode =
                "0x608060405234801561001057600080fd5b50610447806100206000396000f30060806040526004361061004c576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680630a8d65b614610051578063152aa7ca1461011b575b600080fd5b34801561005d57600080fd5b5061008a6004803603810190808035600019169060200190929190803590602001909291905050506101ac565b604051808773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001858152602001848152602001838152602001828152602001965050505050505060405180910390f35b34801561012757600080fd5b506101926004803603810190808035600019169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190803590602001909291908035906020019092919080359060200190929190505050610244565b604051808215151515815260200191505060405180910390f35b6000602052816000526040600020818154811015156101c757fe5b9060005260206000209060060201600091509150508060000160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060010160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060020154908060030154908060040154908060050154905086565b600061024e6103b8565b60c0604051908101604052808873ffffffffffffffffffffffffffffffffffffffff1681526020013373ffffffffffffffffffffffffffffffffffffffff1681526020018781526020018681526020018581526020018481525090506000808960001916600019168152602001908152602001600020819080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060208201518160010160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060408201518160020155606082015181600301556080820151816004015560a0820151816005015550505060019150509695505050505050565b60c060405190810160405280600073ffffffffffffffffffffffffffffffffffffffff168152602001600073ffffffffffffffffffffffffffffffffffffffff1681526020016000815260200160008152602001600081526020016000815250905600a165627a7a72305820dfeb2f0f92f01e63c77c245a21f721864d33077e40ee06fcfdccb6c2c38b0e5c0029";


            //a managed account uses personal_sendTransanction with the given password, this way we don't need to unlock the account for a certain period of time
            var account = new ManagedAccount(rental.Tenant, password);

            //using the specific geth web3 library to allow us manage the mining.
            var web3 = new Nethereum.Web3.Web3("http://127.0.0.1:7545");
            var receipt = new TransactionReceipt();
            try
            {
                receipt = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(byteCode, rental.Tenant, new HexBigInteger(900000));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



            var contractAddress = receipt.ContractAddress;

            var contract = web3.Eth.GetContract(abi, contractAddress);

            var storeFunction = contract.GetFunction("StoreRental");
            var documentsFunction = contract.GetFunction("rentals");
            var t = new Bytes32TypeEncoder();

            try
            {
                var transactionHash = await storeFunction.SendTransactionAsync(from: rental.Tenant, gasPrice: null, gas: new HexBigInteger(2100000), value: null, functionInput: new object[] { "key1", rental.Landlord, rental.Tenant, rental.DepositeAmount, rental.RentalPrice, rental.Endtime, rental.ItemId });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<Rental>> GetAllContractsFromLandlord(string landlord, string password)
        {
            var abi =
                @"[ { 'constant': true, 'inputs': [ { 'name': '', 'type': 'bytes32' }, { 'name': '', 'type': 'uint256' } ], 'name': 'rentals', 'outputs': [ { 'name': 'landlord', 'type': 'address' }, { 'name': 'tenant', 'type': 'address' }, { 'name': 'depositeAmount', 'type': 'uint256' }, { 'name': 'rentalPrice', 'type': 'uint256' }, { 'name': 'endtime', 'type': 'uint256' }, { 'name': 'itemId', 'type': 'uint256' } ], 'payable': false, 'stateMutability': 'view', 'type': 'function' }, { 'constant': false, 'inputs': [ { 'name': 'key', 'type': 'bytes32' }, { 'name': 'landlord', 'type': 'address' }, { 'name': 'depositeAmount', 'type': 'uint256' }, { 'name': 'rentalPrice', 'type': 'uint256' }, { 'name': 'endtime', 'type': 'uint256' }, { 'name': 'itemId', 'type': 'uint256' } ], 'name': 'StoreRental', 'outputs': [ { 'name': 'success', 'type': 'bool' } ], 'payable': false, 'stateMutability': 'nonpayable', 'type': 'function' } ]";

            var byteCode =
                "0x608060405234801561001057600080fd5b50610447806100206000396000f30060806040526004361061004c576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680630a8d65b614610051578063152aa7ca1461011b575b600080fd5b34801561005d57600080fd5b5061008a6004803603810190808035600019169060200190929190803590602001909291905050506101ac565b604051808773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001858152602001848152602001838152602001828152602001965050505050505060405180910390f35b34801561012757600080fd5b506101926004803603810190808035600019169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190803590602001909291908035906020019092919080359060200190929190505050610244565b604051808215151515815260200191505060405180910390f35b6000602052816000526040600020818154811015156101c757fe5b9060005260206000209060060201600091509150508060000160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060010160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060020154908060030154908060040154908060050154905086565b600061024e6103b8565b60c0604051908101604052808873ffffffffffffffffffffffffffffffffffffffff1681526020013373ffffffffffffffffffffffffffffffffffffffff1681526020018781526020018681526020018581526020018481525090506000808960001916600019168152602001908152602001600020819080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060208201518160010160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060408201518160020155606082015181600301556080820151816004015560a0820151816005015550505060019150509695505050505050565b60c060405190810160405280600073ffffffffffffffffffffffffffffffffffffffff168152602001600073ffffffffffffffffffffffffffffffffffffffff1681526020016000815260200160008152602001600081526020016000815250905600a165627a7a72305820dfeb2f0f92f01e63c77c245a21f721864d33077e40ee06fcfdccb6c2c38b0e5c0029";


            //a managed account uses personal_sendTransanction with the given password, this way we don't need to unlock the account for a certain period of time
            var account = new ManagedAccount(landlord, password);

            //using the specific geth web3 library to allow us manage the mining.
            var web3 = new Nethereum.Web3.Web3("http://127.0.0.1:7545");
            var receipt = new TransactionReceipt();
            try
            {
                receipt = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(byteCode, landlord, new HexBigInteger(900000));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



            var contractAddress = receipt.ContractAddress;

            var contract = web3.Eth.GetContract(abi, contractAddress);
            var documentsFunction = contract.GetFunction("rentals");

            var result = new Rental();
            try
            {
                result = await documentsFunction.CallDeserializingToObjectAsync<Rental>("key1", 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }

        public async Task<IEnumerable<Rental>> GetAllContractsFromTenant(string tenant, string password)
        {
            var abi =
                @"[ { 'constant': true, 'inputs': [ { 'name': '', 'type': 'bytes32' }, { 'name': '', 'type': 'uint256' } ], 'name': 'rentals', 'outputs': [ { 'name': 'tenant', 'type': 'address' }, { 'name': 'tenant', 'type': 'address' }, { 'name': 'depositeAmount', 'type': 'uint256' }, { 'name': 'rentalPrice', 'type': 'uint256' }, { 'name': 'endtime', 'type': 'uint256' }, { 'name': 'itemId', 'type': 'uint256' } ], 'payable': false, 'stateMutability': 'view', 'type': 'function' }, { 'constant': false, 'inputs': [ { 'name': 'key', 'type': 'bytes32' }, { 'name': 'tenant', 'type': 'address' }, { 'name': 'depositeAmount', 'type': 'uint256' }, { 'name': 'rentalPrice', 'type': 'uint256' }, { 'name': 'endtime', 'type': 'uint256' }, { 'name': 'itemId', 'type': 'uint256' } ], 'name': 'StoreRental', 'outputs': [ { 'name': 'success', 'type': 'bool' } ], 'payable': false, 'stateMutability': 'nonpayable', 'type': 'function' } ]";

            var byteCode =
                "0x608060405234801561001057600080fd5b50610447806100206000396000f30060806040526004361061004c576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680630a8d65b614610051578063152aa7ca1461011b575b600080fd5b34801561005d57600080fd5b5061008a6004803603810190808035600019169060200190929190803590602001909291905050506101ac565b604051808773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001858152602001848152602001838152602001828152602001965050505050505060405180910390f35b34801561012757600080fd5b506101926004803603810190808035600019169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190803590602001909291908035906020019092919080359060200190929190505050610244565b604051808215151515815260200191505060405180910390f35b6000602052816000526040600020818154811015156101c757fe5b9060005260206000209060060201600091509150508060000160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060010160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060020154908060030154908060040154908060050154905086565b600061024e6103b8565b60c0604051908101604052808873ffffffffffffffffffffffffffffffffffffffff1681526020013373ffffffffffffffffffffffffffffffffffffffff1681526020018781526020018681526020018581526020018481525090506000808960001916600019168152602001908152602001600020819080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060208201518160010160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060408201518160020155606082015181600301556080820151816004015560a0820151816005015550505060019150509695505050505050565b60c060405190810160405280600073ffffffffffffffffffffffffffffffffffffffff168152602001600073ffffffffffffffffffffffffffffffffffffffff1681526020016000815260200160008152602001600081526020016000815250905600a165627a7a72305820dfeb2f0f92f01e63c77c245a21f721864d33077e40ee06fcfdccb6c2c38b0e5c0029";


            //a managed account uses personal_sendTransanction with the given password, this way we don't need to unlock the account for a certain period of time
            var account = new ManagedAccount(tenant, password);

            //using the specific geth web3 library to allow us manage the mining.
            var web3 = new Nethereum.Web3.Web3("http://127.0.0.1:7545");
            var receipt = new TransactionReceipt();
            try
            {
                receipt = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(byteCode, tenant, new HexBigInteger(900000));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



            var contractAddress = receipt.ContractAddress;

            var contract = web3.Eth.GetContract(abi, contractAddress);
            var documentsFunction = contract.GetFunction("rentals");

            var result = new Rental();
            try
            {
                result = await documentsFunction.CallDeserializingToObjectAsync<Rental>("key1", 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }

    }
}