// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Christian Hornung" email=""/>
//     <version>$Revision$</version>
// </file>

using System;
using Hornung.ResourceToolkit.ResourceFileContent;
using ICSharpCode.SharpDevelop.Dom;

namespace Hornung.ResourceToolkit.Resolver
{
	/// <summary>
	/// Describes a reference to a resource.
	/// </summary>
	public class ResourceResolveResult : ResolveResult
	{
		
		ResourceSetReference resourceSetReference;
		string key;
		
		/// <summary>
		/// Gets the <see cref="ResourceSetReference"/> that describes the resource set being referenced.
		/// </summary>
		public ResourceSetReference ResourceSetReference {
			get { return this.resourceSetReference; }
		}
		
		/// <summary>
		/// Gets the <see cref="IResourceFileContent"/> for the referenced resource set.
		/// May be <c>null</c>.
		/// </summary>
		public IResourceFileContent ResourceFileContent {
			get {
				if (this.ResourceSetReference == null ||
				    this.ResourceSetReference.FileName == null) {
					return null;
				}
				return this.ResourceSetReference.ResourceFileContent;
			}
		}
		
		/// <summary>
		/// Gets the resource key being referenced. May be null if the key is unknown/not yet typed.
		/// </summary>
		public string Key {
			get { return this.key; }
		}
		
		/// <summary>
		/// Gets the resource file name that contains the resource being referenced.
		/// Only valid if <see cref="ResourceSetReference"/> is not <c>null</c>
		/// and the <see cref="ResourceSetReference"/> contains a valid file name.
		/// </summary>
		public string FileName {
			get {
				
				IMultiResourceFileContent mrfc = this.ResourceFileContent as IMultiResourceFileContent;
				if (mrfc != null && this.Key != null) {
					return mrfc.GetFileNameForKey(this.Key);
				} else if (this.ResourceFileContent != null) {
					return this.ResourceFileContent.FileName;
				} else if (this.ResourceSetReference != null) {
					return this.ResourceSetReference.FileName;
				}
				
				return null;
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ResourceResolveResult"/> class.
		/// </summary>
		/// <param name="callingClass">The class that contains the reference to the resource.</param>
		/// <param name="callingMember">The member that contains the reference to the resource.</param>
		/// <param name="returnType">The type of the resource being referenced.</param>
		/// <param name="resourceSetReference">The <see cref="ResourceSetReference"/> that describes the resource set being referenced.</param>
		/// <param name="key">The resource key being referenced.</param>
		public ResourceResolveResult(IClass callingClass, IMember callingMember, IReturnType returnType, ResourceSetReference resourceSetReference, string key)
			: base(callingClass, callingMember, returnType)
		{
			this.resourceSetReference = resourceSetReference;
			this.key = key;
		}
		
	}
}
