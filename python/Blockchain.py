# -*- coding: utf-8 -*-
"""
Spyder Editor

Author: Onyinyechukwu Orji
Create a Blockchain
"""
import datetime
import hashlib
import json
from flask import Flask, jsonify

# Part 1 - Building a Blockchain


class Blockchain:
# initialze self method
    def __init__(self):
        self.chain = []
        self.create_block(proof=1, previous_hash='0')
# initialize create a block function
    def create_block(self, proof, previous_hash):
        block = {'index': len(self.chain) + 1,
                 'timestamp': str(datetime.datetime.now()),
                 'proof': proof,
                 'previous_hash': previous_hash}
        self.chain.append(block)
        return block
# initialize get previous block function    
    def get_previous_block(self):
        return self.chain[-1]
# initialize proof of work crytpographical function   
    def proof_of_work(self, previous_proof):
        new_proof = 1
        check_proof = False
        while check_proof is False:
            hash_operation = hashlib.sha256(str(new_proof**2 - previous_proof**2).encode()).hexdigest()
            if hash_operation[:4] == '0000':
                check_proof = True
            else:
                new_proof += 1           
        return new_proof
# validate hash chain
    def hash(self, block):
        encoded_block = json.dumps(block, sort_keys = True).encode()
        return hashlib.sha256(encoded_block).hexdigest()
# Part 2 - Mining our Blockchain
