module.exports = {
	"root": true,

	"env": {
		"browser": true,
		"node": true,
		"es6": true,
		"jest": true,
	},
	"extends": [
		"eslint:recommended",
		"plugin:react/recommended",
		"plugin:@typescript-eslint/recommended"
	],
	"parserOptions": {
		"ecmaFeatures": {
			"jsx": true
		},
		"ecmaVersion": 13,
		"sourceType": "module"
	},
	"plugins": [
		"react",
		"import",
		"promise",
		"@typescript-eslint"
	],

	"settings": {
		"react": {
			"version": "detect",
		},
		"import/extensions": [
			".js",
		],
		"import/ignore": [
			"node_modules",
			"\\.(css|scss|json)$",
		],
		"import/resolver": {
			"node": {
				"paths": [
					"app/javascript"
				],
			}
		}
	},

	"rules": {
		"array-bracket-newline": "off",
		"array-bracket-spacing": "off",
		"array-callback-return": "off",
		"array-element-newline": "off",
		"arrow-body-style": "off",
		"arrow-parens": "off",
		"arrow-spacing": "off",
		"block-scoped-var": "off",
		"block-spacing": "off",
		"brace-style": "off",
		"camelcase": "off",
		"capitalized-comments": "off",
		"class-methods-use-this": "off",
		"comma-dangle": "off",
		"comma-spacing": "off",
		"comma-style": "off",
		"complexity": "off",
		"computed-property-spacing": [
			"error",
			"never"
		],
		"consistent-return": "off",
		"consistent-this": "off",
		"curly": "off",
		"default-case": "off",
		"default-case-last": "off",
		"default-param-last": "error",
		"dot-location": [
			"error",
			"property"
		],
		"dot-notation": "off",
		"eol-last": "off",
		"eqeqeq": "off",
		"func-call-spacing": "error",
		"func-name-matching": "off",
		"func-names": "off",
		"func-style": "off",
		"function-call-argument-newline": "off",
		"function-paren-newline": "off",
		"generator-star-spacing": "error",
		"grouped-accessor-pairs": "error",
		"guard-for-in": "off",
		"id-denylist": "error",
		"id-length": "off",
		"id-match": "error",
		"implicit-arrow-linebreak": "off",
		"indent": "off",
		"init-declarations": "off",
		"jsx-quotes": "off",
		"key-spacing": "off",
		"keyword-spacing": "off",
		"line-comment-position": "off",
		"linebreak-style": [
			"error",
			"unix"
		],
		"lines-around-comment": "off",
		"lines-between-class-members": "off",
		"max-classes-per-file": "off",
		"max-depth": "off",
		"max-len": "off",
		"max-lines": "off",
		"max-lines-per-function": "off",
		"max-nested-callbacks": "error",
		"max-params": "off",
		"max-statements": "off",
		"max-statements-per-line": "off",
		"multiline-comment-style": "off",
		"multiline-ternary": "off",
		"new-parens": "off",
		"newline-per-chained-call": "off",
		"no-alert": "error",
		"no-array-constructor": "error",
		"no-await-in-loop": "off",
		"no-bitwise": "off",
		"no-caller": "error",
		"no-confusing-arrow": "off",
		"no-console": "off",
		"no-constructor-return": "error",
		"no-continue": "off",
		"no-div-regex": "error",
		"no-duplicate-imports": "error",
		"no-else-return": "off",
		"no-empty-function": "off",
		"no-eq-null": "off",
		"no-eval": "error",
		"no-extend-native": "error",
		"no-extra-bind": "error",
		"no-extra-label": "off",
		"no-extra-parens": "off",
		"no-extra-semi": "off",
		"no-floating-decimal": "error",
		"no-implicit-coercion": [
			"error",
			{
				"boolean": false,
				"disallowTemplateShorthand": false,
				"number": false,
				"string": false
			}
		],
		"no-implicit-globals": "error",
		"no-implied-eval": "error",
		"no-inline-comments": "off",
		"no-inner-declarations": [
			"error",
			"functions"
		],
		"no-invalid-this": "off",
		"no-iterator": "error",
		"no-label-var": "off",
		"no-labels": "off",
		"no-lone-blocks": "off",
		"no-lonely-if": "off",
		"no-loop-func": "off",
		"no-magic-numbers": "off",
		"no-mixed-operators": "off",
		"no-multi-assign": "off",
		"no-multi-spaces": "off",
		"no-multi-str": "error",
		"no-multiple-empty-lines": "off",
		"no-negated-condition": "off",
		"no-nested-ternary": "off",
		"no-new": "off",
		"no-new-func": "error",
		"no-new-object": "error",
		"no-new-wrappers": "error",
		"no-octal-escape": "error",
		"no-param-reassign": "off",
		"no-plusplus": "off",
		"no-promise-executor-return": "off",
		"no-proto": "off",
		"no-restricted-exports": "error",
		"no-restricted-globals": "error",
		"no-restricted-imports": "error",
		"no-restricted-properties": "error",
		"no-restricted-syntax": "error",
		"no-return-assign": "off",
		"no-return-await": "off",
		"no-script-url": "error",
		"no-self-compare": "off",
		"no-sequences": "off",
		"no-shadow": "off",
		"no-tabs": "off",
		"no-template-curly-in-string": "error",
		"no-ternary": "off",
		"no-throw-literal": "error",
		"no-trailing-spaces": "off",
		"no-undef-init": "off",
		"no-undefined": "off",
		"no-underscore-dangle": "off",
		"no-unmodified-loop-condition": "off",
		"no-unneeded-ternary": [
			"error",
			{
				"defaultAssignment": true
			}
		],
		"no-unreachable-loop": "error",
		"no-unused-expressions": "off",
		"no-unused-private-class-members": "error",
		"no-use-before-define": "off",
		"no-useless-call": "error",
		"no-useless-computed-key": "error",
		"no-useless-concat": "off",
		"no-useless-constructor": "off",
		"no-useless-rename": "error",
		"no-useless-return": "off",
		"no-var": "off",
		"no-void": "off",
		"no-warning-comments": "off",
		"no-whitespace-before-property": "error",
		"nonblock-statement-body-position": [
			"error",
			"any"
		],
		"object-curly-newline": "error",
		"object-curly-spacing": "off",
		"object-shorthand": "off",
		"one-var": "off",
		"one-var-declaration-per-line": "off",
		"operator-assignment": "off",
		"operator-linebreak": "off",
		"padded-blocks": "off",
		"padding-line-between-statements": "error",
		"prefer-arrow-callback": "off",
		"prefer-const": "off",
		"prefer-destructuring": "off",
		"prefer-exponentiation-operator": "off",
		"prefer-named-capture-group": "off",
		"prefer-numeric-literals": "error",
		"prefer-object-spread": "off",
		"prefer-promise-reject-errors": [
			"error",
			{
				"allowEmptyReject": true
			}
		],
		"prefer-regex-literals": "error",
		"prefer-rest-params": "off",
		"prefer-spread": "off",
		"prefer-template": "off",
		"quote-props": "off",
		"quotes": "off",
		"radix": [
			"error",
			"always"
		],
		"require-atomic-updates": "off",
		"require-await": "error",
		"require-unicode-regexp": "off",
		"rest-spread-spacing": [
			"error",
			"never"
		],
		"semi": "off",
		"semi-spacing": "off",
		"semi-style": "off",
		"sort-keys": "off",
		"sort-vars": "off",
		"space-before-blocks": "off",
		"space-before-function-paren": "off",
		"space-in-parens": "off",
		"space-infix-ops": "off",
		"space-unary-ops": "off",
		"spaced-comment": "off",
		"strict": "off",
		"switch-colon-spacing": [
			"error",
			{
				"after": false,
				"before": false
			}
		],
		"symbol-description": "error",
		"template-curly-spacing": [
			"error",
			"never"
		],
		"template-tag-spacing": "error",
		"unicode-bom": [
			"error",
			"never"
		],
		"vars-on-top": "off",
		"wrap-iife": "off",
		"wrap-regex": "off",
		"yield-star-spacing": "error",
		"yoda": "off",
		"@typescript-eslint/no-empty-function": "off",
		"@typescript-eslint/no-extra-semi": "off",
	}
};
